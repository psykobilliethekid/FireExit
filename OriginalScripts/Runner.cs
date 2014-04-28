using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {
	//show how far Runner has traveled and update the distance
	public static float distanceTraveled; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(5f * Time.deltaTime, 0f, 0f);
		//update the distance
		distanceTraveled = transform.localPosition.x;
	
	}
}
