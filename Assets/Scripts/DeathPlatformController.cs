using UnityEngine;
using System.Collections;

public class DeathPlatformController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		ScoreController.scoreCount--;

		if (other.gameObject.tag == "Penguin") 
		{
			//game over
			var gameOver = GameObject.Find("GameOver");
			print("Gameover is null: " + (gameOver == null));
			gameOver.SetActive(true);
			GameObject.Find("Game").SetActive(false);
		}

		Destroy(other.gameObject);

	}
}
