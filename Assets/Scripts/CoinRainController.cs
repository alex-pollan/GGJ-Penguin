using UnityEngine;
using System.Collections;

public class CoinRainController : MonoBehaviour {

	public Rigidbody2D coin;
	public float timer = 1f;
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
				? new Vector3(Random.Range(-4.5f, -1.0f), 10.0f ,0.0f)
					: new Vector3(Random.Range(1.0f, 4.5f), 10.0f, 0.0f);
			
			Instantiate (coin, position, Quaternion.identity);
		}

	}
}
