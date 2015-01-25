using UnityEngine;
using System.Collections;

public class DeathPlatformController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		ScoreController.scoreCount--;

		if (other.gameObject.tag == "Penguin") 
		{
			//game over
			GameController.GameOver.SetActive(true);

			GameObject game = GameObject.Find("Game");
			game.SetActive(false);
		}

		Destroy(other.gameObject);

	}
}
