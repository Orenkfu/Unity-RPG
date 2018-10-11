using System;
using UnityEngine;
using UnityEngine.AI;
using RPG.CameraUI;

namespace RPG.Characters {

[RequireComponent(typeof(ThirdPersonCharacter))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AICharacterControl))]
public class PlayerMovement : MonoBehaviour {
    CameraRaycaster cameraRaycaster;

    [Header("Stop Range Variables")]
    [SerializeField] float walkMoveStopRadius = 0.2f;
    [SerializeField] float interactRange;

    GameObject walkTarget = null;
    AICharacterControl aiControl = null;

    private void Start() {
        walkTarget = new GameObject("Walk Target");
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        aiControl = GetComponent<AICharacterControl>();

        cameraRaycaster.notifyWalkableObservers += OnMouseOverWalkable;
        cameraRaycaster.notifyEnemyObservers += OnMouseOverEnemy;

            //cameraRaycaster.notifyMouseClickObservers += ProcessMouseClick;
        }

        private void OnMouseOverEnemy(Enemy enemy) {
            if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(1)) {
                MoveToDestination(enemy.transform.position);
            }
        }

        private void OnMouseOverWalkable(Vector3 destination) {
            if (Input.GetMouseButton(0)) {
                MoveToDestination(destination);
             }
            }

    void MoveToDestination(Vector3 destination) {
            walkTarget.transform.position = destination;
            aiControl.SetTarget(walkTarget.transform);
        }
   
    Vector3 ShortDestination(Vector3 destination, float shortening) {
        Vector3 reductionVector = (destination - transform.position).normalized * shortening;
        return destination- reductionVector;
    }
    }

}

