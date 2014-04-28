using UnityEngine;
using System.Collections;

public class Reduce : MonoBehaviour {
	
	public Vector3 offset, rotationVelocity;
	public float recycleOffset, spawnChance;
	

	// Use this for initialization
	void Start () {
		GameEventManager.GameOver += GameOver;
		gameObject.active = false;
	
	}
	// Update is called once per frame
	void Update () {
		if(transform.localPosition.x + recycleOffset < Runner.distanceTraveled)
		{
			gameObject.active = false;
			return;
		}
		transform.Rotate (rotationVelocity * Time.deltaTime);
	}
	
	void OnTriggerEnter()
	{
		Runner.AddReduce();
		gameObject.active = false;
	}
	
	//spawn if available
	public void SpawnIfAvailable(Vector3 position)
	{
		if(gameObject.active || spawnChance <= Random.Range(0f, 100f))
		{
			return;
		}
		transform.localPosition = position + offset;
		gameObject.active = true;
	}
	
	private void GameOver()
	{
		gameObject.active = false;
	}
	
	
}
