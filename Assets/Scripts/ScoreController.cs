using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {
	
	public static int scoreCount = 0;
	
	// Update is called once per frame
	void Update () {
		if (scoreCount <= -100) {
			GameController.SetGameOver();
		}
	}
	
	void OnGUI()
	{
		string scoreText = "Score: " + scoreCount;
		GUI.Box (new Rect(Screen.width - 150, 20, 130, 20), scoreText);
	}
}