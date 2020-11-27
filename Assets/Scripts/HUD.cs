using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
	AnyPlayerBehavior playerScript;
	AnyPlayerBehavior enemyScript;
	public float gameLength = 60; //in seconds
	//text writing data
	private GUIStyle style;
	private Rect rect;
	//endgame flag (to draw end game stats on screen
	private bool gameOver = false;

	void Start()
    {
		//prepare GUI data (originally from FPS counter shown in class, changed for my own usage)
		int w = Screen.width, h = Screen.height;
		rect = new Rect(0, 0, w, h * 2 / 100);
		style = new GUIStyle();
		style.fontSize = h * 4 / 100;
		style.normal.textColor = Color.white;
		//get players to follow their scores
		playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerControls>();
		enemyScript = GameObject.FindWithTag("Enemy").GetComponent<EnemyBehavior>();
	}

	void Update()
	{
		gameLength -= Time.deltaTime;
		if (gameLength <= 1) //so timer will show zero
        {
			
			finishGame();
        }
	}

	void OnGUI()
	{
		style.alignment = TextAnchor.UpperLeft;
		GUI.Label(rect, "Time Left: " + (int) gameLength, style);
		style.alignment = TextAnchor.UpperRight;
		//score
		GUI.Label(rect, "Player Score = " + playerScript.score + "\n" + "Enemy Score = " + enemyScript.score, style);
        if (gameOver)
        {
			int w = Screen.width, h = Screen.height;
			Rect endRect = new Rect(0, h / 4, w, h * 2 / 100);
			style.alignment = TextAnchor.MiddleCenter;
			GUI.Label(endRect, "Game Over!\nFinal score (yours - enemy): " + (playerScript.score - enemyScript.score), style);
		}
	}

	private void finishGame()
    {
		gameOver = true;
		Time.timeScale = 0; // this will freeze the game - last line to do
	}
}