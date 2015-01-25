using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	private static GameObject GameOver;

	// Use this for initialization
	void Start () {
		GameOver = GameObject.Find ("GameOver");
		GameOver.SetActive(false);
		this.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void SetGameOver()
	{
		//game over
		GameOver.SetActive(true);
		GameObject.Find("Game").SetActive(false);
	}
}
