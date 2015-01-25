using UnityEngine;
using System.Collections;

public class DeathPlatformController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		ScoreController.scoreCount--;

		if (other.gameObject.tag == "Penguin") 
		{
			GameController.SetGameOver();
		
		}

		Destroy(other.gameObject);

	}
}
