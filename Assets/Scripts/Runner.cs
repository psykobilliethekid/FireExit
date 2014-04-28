using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {
	//show how far Runner has traveled and update the distance
	public static float distanceTraveled; 
	
	public float acceleration;
	//making the Runner jump
	public Vector3 reduceVelocity, jumpVelocity;
	
	//where the runner drops to and shows game over
	public float gameOverY;
	
	//game timer set to 10 seconds
	//public float timer = 10.0f;
	
	private bool touchingPlatform;
	//starting position for Runner
	private Vector3 startPosition;
	
	private static int reduce;

	// Use this for initialization
	void Start () {
		//Has Runner hidden before the game starts
		GameEventManager.GameStart += GameStart;
		//shows the game is over
		GameEventManager.GameOver += GameOver;
		startPosition = transform.localPosition;
		gameObject.active = false;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//to make the Runner jump
		if(touchingPlatform && Input.GetButtonDown("Jump"))
		{
			rigidbody.AddForce(jumpVelocity, ForceMode.VelocityChange);
			touchingPlatform = false;
		}
		else if(reduce > 0)
		{
			rigidbody.AddForce(reduceVelocity, ForceMode.VelocityChange);
			reduce += 1;
			GUIManager.SetReduce(reduce);
		}
		//update the distance traveled
		distanceTraveled = transform.localPosition.x;
		GUIManager.SetDistance(distanceTraveled);
			
		//shows game over
		if(transform.localPosition.y < gameOverY)
		{
			GameEventManager.TriggerGameOver();
		}
			
	}
	
	void FixedUpdate()
	{
		if(touchingPlatform)
		{
			rigidbody.AddForce(acceleration, 0f, 0f, ForceMode.Acceleration);
		}
	}
	
	void OnCollisionEnter()
	{
		touchingPlatform = true;
	}
	
	void OnCollisionExit()
	{
		touchingPlatform = false;
	}
	
	private void GameStart()
	{	
		reduce = 0;
		GUIManager.SetReduce(reduce);
		distanceTraveled = 0f;
		GUIManager.SetDistance(distanceTraveled);
		transform.localPosition = startPosition;
		//GUIManager.SetTime(timeLeft);	
		
		//Freezes Runner once game is over
		rigidbody.isKinematic = false;
		gameObject.active = true;
		enabled = true;
	}
	
	private void GameOver()
	{
		rigidbody.isKinematic = true;
		enabled = false;
	}
	
	public static void AddReduce()
	{
		reduce -= 1;
		GUIManager.SetReduce(reduce);
	}
	
	
		
}