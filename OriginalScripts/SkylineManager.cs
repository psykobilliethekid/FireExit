using UnityEngine;
using System.Collections.Generic;

public class SkylineManager : MonoBehaviour {
	
	//find the prefab to use
	public Transform prefab;
	
	//determine how many cubes to spawn to fill screen
	public int numberOfObjects; 
	
	//recycle the first object to appear on the screen again
	public float recycleOffset;
	
	private Vector3 nextPosition;
	private Queue<Transform> objectQueue;

	// Use this for initialization
	void Start () {
		objectQueue = new Queue<Transform>(numberOfObjects);
		nextPosition = transform.localPosition;
		//spawn initial row of cubes
		for(int i=0; i < numberOfObjects; i++)
		{
			Transform o = (Transform)Instantiate(prefab);
			o.localPosition = nextPosition;
			nextPosition.x += o.localScale.x;
			objectQueue.Enqueue(o);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		//recycle the objects after the runner has traveled a certain amt of distance over time
		if(objectQueue.Peek().localPosition.x + recycleOffset < Runner.distanceTraveled)
		{
			Transform o = objectQueue.Dequeue();
			o.localPosition = nextPosition;
			nextPosition.x += o.localScale.x;
			objectQueue.Enqueue(o);
		}
	
	}
}
