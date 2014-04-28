using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {
	
	public GUIText timerText, reduceText, distanceText, gameOverText, instructionsText, runnerText;
	
	private static GUIManager instance;

	// Use this for initialization
	void Start () {
		instance = this;
		//shows the game has started
		GameEventManager.GameStart += GameStart;
		timerText.enabled = false;
	
		
		//shows the game has ended
		GameEventManager.GameOver += GameOver;
		gameOverText.enabled = false;
	
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown("Jump"))
		{
			GameEventManager.TriggerGameStart();
			timerText.enabled = true;
		}
		
	}
	
	//Starts the Game, Disables all text, Disables manager to not call update method
	private void GameStart()
	{
		gameOverText.enabled = false; 
		instructionsText.enabled = false; 
		runnerText.enabled = false;
		timerText.enabled = false;
		enabled = false;
	}
	
	//Ends the Game, shows game over text and instructions
	private void GameOver()
	{
		gameOverText.enabled = true;
		instructionsText.enabled = true; 
		timerText.enabled = false;
		enabled = true;
	}
	
	public static void SetReduce(int reduce)
	{
		instance.reduceText.text = reduce.ToString();
	}
	
	public static void SetDistance(float distance)
	{
		instance.distanceText.text = distance.ToString("f0");
	}
	
	public static void SetTime(float timer)
	{
		instance.timerText.text = timer.ToString("f10.0");
	}
	
}
