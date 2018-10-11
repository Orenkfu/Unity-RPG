using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using RPG.Characters;
using System;

namespace RPG.CameraUI {
    public class CameraRaycaster : MonoBehaviour {
        [SerializeField] int walkableLayer = 8;
        [SerializeField] Texture2D walkCursor = null;
        [SerializeField] Texture2D interactCursor = null;
        [SerializeField] Texture2D enemyCursor = null;
        [SerializeField] Texture2D buttonCursor = null;
        [SerializeField] Vector2 cursorHotspot = new Vector2(0, 0);

        public delegate void OnMouseOverEnemy(Enemy enemy);
        public event OnMouseOverEnemy notifyEnemyObservers;
        public delegate void OnMouseOverWalkable(Vector3 destination);
        public event OnMouseOverWalkable notifyWalkableObservers;
       
        Rect screenRectAtStart = new Rect(0, 0, Screen.width, Screen.height); //TODO: broadcast even when screen changes and update the rect..
        const float MAX_RAYCAST_DEPTH = 100f;

        void Update() {
            if (!EventSystem.current.IsPointerOverGameObject()) {
                MouseRaycast();
            }
        }

        void MouseRaycast() {
            if (!screenRectAtStart.Contains(Input.mousePosition)) { return; }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (RaycastForEnemy(ray, out hitInfo)) {
                Cursor.SetCursor(enemyCursor, cursorHotspot, CursorMode.Auto);
                notifyEnemyObservers(hitInfo.collider.gameObject.GetComponent<Enemy>());
                return;
            }
            if (RaycastForInteractable(ray)) {
                //TODO: create an Interactable interface and interaction system.
                //  return;
            }
            if (RaycastForWalkable(ray, out hitInfo)) {
                Cursor.SetCursor(walkCursor, cursorHotspot, CursorMode.Auto);
                notifyWalkableObservers(hitInfo.point);
                return;
            }
        }

        private bool RaycastForInteractable(Ray ray) {

            return true;
        }

        private bool RaycastForEnemy(Ray ray, out RaycastHit hitInfo) {
            Physics.Raycast(ray, out hitInfo, MAX_RAYCAST_DEPTH);
            var gameObjectHit = hitInfo.collider.gameObject;
            if (!gameObjectHit) { return false; }
            if (gameObjectHit.GetComponent<Enemy>()) {
                return true;
            }
            return false;
        }

        private bool RaycastForWalkable(Ray ray, out RaycastHit hitInfo) {
            LayerMask walkableLayerMask = 1 << this.walkableLayer;
            return Physics.Raycast(ray, out hitInfo, MAX_RAYCAST_DEPTH, walkableLayerMask); //use unity physics magic to find out if a walkable layer has been hit
        }
    }
}