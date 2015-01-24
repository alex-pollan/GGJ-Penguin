using UnityEngine;
using System.Collections;

public class FoodRainController : MonoBehaviour {

	public float timer = 1f;
	public float MinX = -4.5f;
	public float MaxX = 4.5f;

	private float timerBackup;

	void Start()
	{
		timerBackup = timer;
	}

	void Update () {
		timer -= Time.deltaTime;

		if (timer <= 0) 
		{
			timer = timerBackup;
			
			Vector3 position = Random.value > 0.5 
				? new Vector3(Random.Range(MinX, -0.5f), 10.0f ,0.0f)
					: new Vector3(Random.Range(0.5f, MaxX), 10.0f, 0.0f);

			GameObject food = Random.value > 0.5 
				? GameObject.Find("Food")
				: GameObject.Find("Food2");
			GameObject clone = Instantiate (food, position, Quaternion.identity) as GameObject;
			clone.SetActive(true);
			clone.rigidbody2D.isKinematic = false;
			GameObject game = GameObject.Find("FoodCol");
			clone.transform.parent = game.transform;
		}

	}
}
