using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class BoardController : MonoBehaviour {
	
	Scene thisScene;
	private IEnumerator coroutineRotate4;
	private IEnumerator coroutineRotate5;
	// Use this for initialization
	void Start () {
		thisScene = SceneManager.GetActiveScene();

		coroutineRotate4 = RotateLvl4();
		coroutineRotate5 = RotateLvl5();
	}
	
	private IEnumerator RotateLvl5() {
		float time = 4;     //How long will the object be rotated?
 
     	while(time > 0)     //While the time is more than zero...
     	{
        	// calculate rotation speed
         	float rotationSpeed = 5 / 4;
 
         	while (true)
        	{
             	// save starting rotation position
             	Quaternion startRotation = transform.rotation;
 
             	float deltaAngle = 0;
 
             	// rotate until reaching angle
             	while (deltaAngle < 5)
             	{
                 	deltaAngle += rotationSpeed * Time.deltaTime;
                 	deltaAngle = Mathf.Min(deltaAngle, 5);
 
                 	transform.rotation = startRotation * Quaternion.AngleAxis(deltaAngle, Vector3.back);
 
                 	yield return null;
             	}
 
             	// delay here
             	yield return new WaitForSeconds(1);
         	}
     	}
	}
	
	private IEnumerator	RotateLvl4() {
		float time = 5;     //How long will the object be rotated?
 
     	while(time > 0)     //While the time is more than zero...
     	{
        	transform.Rotate(Vector3.up, Time.deltaTime * 200.0f);     //...rotate the object.
          	time -= Time.deltaTime;     //Decrease the time- value one unit per second.
 
          	yield return null;     //Loop the method.
     	}
	}

	// Update is called once per frame
	void Update () {
		switch(thisScene.buildIndex) {
			case 1:
				//rotate the dartboard
				transform.Rotate (new Vector3 (0, 0, -90) * Time.deltaTime);
				break;
			case 2:
				//rotate the dartboard
				transform.Rotate (new Vector3 (0, 0, -180) * Time.deltaTime);
				break;
			case 3:
				//rotate the dartboard
				transform.Rotate (new Vector3 (0, 0, -270) * Time.deltaTime);
				break;
			case 4:
				transform.Rotate (new Vector3 (0, 0, 270) * Time.deltaTime);
				break;
			case 5:
				//StartCoroutine(coroutineRotate5);
				transform.Rotate (new Vector3 (0, 0, 500) * Time.deltaTime);
				break;
			default: 
				break;
		}
	}
}
