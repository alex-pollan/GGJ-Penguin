using UnityEngine;
using System.Collections;

public class FoodController : MonoBehaviour {

	void Start () {

	}
	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag != "Player")
		{
			audio.Play ();
		}
		
	}
}
