using UnityEngine;
using System;
using System.Collections.Generic;

public class CountdownTimer : MonoBehaviour
{
	
	public float timeLeft = 10.0f;
	private float resetTime;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		timeLeft -= Time.deltaTime;
		
		if (timeLeft <= 0.0f) 
		{
			//End the level here
			guiText.text = "Time!";
			GameEventManager.TriggerGameOver ();
		} 
		else 
		{
			guiText.text = "Time left: " + (int)timeLeft + " seconds";
		}
		
	}
	
	void ResetTimer()
	{
		if(timeLeft >= 0.0f)
		{
			GameEventManager.TriggerGameStart();
		}
	}
	

}
