using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   // void OnCollisionEnter(Collider collider) {
     //   Invoke("Down", 2f);
    //}
    void Down() {
        transform.position = new Vector3(transform.position.x, transform.position.y - 6, transform.position.z);
    }
}

