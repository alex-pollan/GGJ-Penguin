using UnityEngine;
using System.Collections;

public class IcebergController : MonoBehaviour {
	
	public Rigidbody2D iceberg;
	private float timer = 1f;
	
	private bool shouldMove = true;
	
	private float acceleration = 0.05f;
	
	private float minAcceleration = 0.005f;	
	private float maxAcceleration = 0.05f;
	
	private float maxX = 10f;
	private float minX = -10f;

	private ArrayList collectedObjects = new ArrayList();
	
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
		if (iceberg.position.x > maxX) {
			resetIcebergPosition();
			killCollectedObjects();

			shouldMove = false;
		} else {
			iceberg.MovePosition (new Vector2 (iceberg.position.x + acceleration, iceberg.position.y));
		}
	}

	void killCollectedObjects()
	{
		while (collectedObjects.Count > 0) {
			UnityEngine.Object obj = collectedObjects[0] as UnityEngine.Object;
			Destroy( obj );
			collectedObjects.RemoveAt(0);
		}
	}

	void resetIcebergPosition()
	{
		iceberg.MovePosition (new Vector2 (minX, iceberg.position.y));
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		collectedObjects.Add (other);
	}
}
