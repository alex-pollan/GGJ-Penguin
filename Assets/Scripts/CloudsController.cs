using UnityEngine;
using System.Collections;

public class CloudsController : MonoBehaviour {
	
	public Rigidbody2D clouds;
	private float timer = 1f;
	
	private bool shouldMove = true;
	
	private float acceleration = 0.05f;
	
	private float minAcceleration = 0.005f;	
	private float maxAcceleration = 0.01f;
	
	private float maxX = 20f;
	private float minX = -12f;

	void Start()
	{
	}
	
	void Update () {
		if (shouldMove) {
			moveIceberg ();
		} else {
			timer -= Time.deltaTime;
			
			if (timer <= 0) {
				timer = Random.Range (1, 5);
				acceleration = Random.Range( minAcceleration, maxAcceleration);
				print ( acceleration);
				Random.seed = 1;
				shouldMove = true;
			}
		}
	}
	
	void moveIceberg(){
		if (clouds.position.x > maxX) {
			resetCloudsPosition();

			shouldMove = false;
		} else {
			clouds.MovePosition (new Vector2 (clouds.position.x + acceleration, clouds.position.y));
		}
	}
	
	void resetCloudsPosition()
	{
		clouds.MovePosition (new Vector2 (minX, clouds.position.y));
	}
}
