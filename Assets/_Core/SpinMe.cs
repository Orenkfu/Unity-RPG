using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Core {
    public class SpinMe : MonoBehaviour {

        [SerializeField] float xRotationsPerMinute = 1f;
        [SerializeField] float yRotationsPerMinute = 1f;
        [SerializeField] float zRotationsPerMinute = 1f;

        void Update() {
            //xDegreesPerFrame = Time.deltaTime, 60, 360, xRotationsPerMinute
            //degrees frame^-1 = seconds frame^-1, seconds minute^-1
            float framesPerSecond = Time.deltaTime / 60;

            float xDegreesPerFrame = framesPerSecond * 360 * xRotationsPerMinute;
            transform.RotateAround(transform.position, transform.right, xDegreesPerFrame);

            float yDegreesPerFrame = framesPerSecond * 360 * yRotationsPerMinute;
            transform.RotateAround(transform.position, transform.up, yDegreesPerFrame);

            float zDegreesPerFrame = framesPerSecond * 360 * zRotationsPerMinute;
            transform.RotateAround(transform.position, transform.forward, zDegreesPerFrame);
        }
    }
}
