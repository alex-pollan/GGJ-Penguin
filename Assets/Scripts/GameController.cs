using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public static GameObject GameOver;

	// Use this for initialization
	void Start () {
		GameOver = GameObject.Find ("GameOver");
		GameOver.SetActive(false);
		this.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
