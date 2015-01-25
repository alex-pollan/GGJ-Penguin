using UnityEngine;
using System.Collections;

public class IcebergController : MonoBehaviour {

	private float timer = 1f;
	private float yChangeTimer = 0.5f;
	
	private bool shouldMove = true;
	
	private float acceleration = 0.05f;
	
	private float minAcceleration = 0.005f;	
	private float maxAcceleration = 0.05f;
	
	private float maxX = 13f;
	private float minX = -10f;

	private float startY;
	private float deltaY = 0.01f;

	private Rigidbody2D iceberg;
	private ArrayList collectedObjects = new ArrayList();
	
	void Start()
	{
		iceberg = this.rigidbody2D;
		startY = iceberg.position.y;
	}
	
	void FixedUpdate () {
		if (shouldMove) {
			if (iceberg.position.x > maxX) {
				shouldMove = false;

				iceberg.position = new Vector2(minX, startY);
				killCollectedObjects();
			} else {
				yChangeTimer -= Time.deltaTime;

				if (yChangeTimer <= 0)
				{
					deltaY *= -1;
					yChangeTimer = Random.Range (0.3f, 0.8f);
				}

				iceberg.MovePosition (new Vector2 (iceberg.position.x + acceleration, iceberg.position.y + deltaY));
			}
		} else {
			timer -= Time.deltaTime;
			
			if (timer <= 0) {
				timer = Random.Range (1, 3);
				acceleration = Random.Range( minAcceleration, maxAcceleration);
				//print ( acceleration);
				Random.seed = 1;
				shouldMove = true;
			}
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

//	void OnCollisionEnter2D(Collision2D coll) 
//	{
//		if (coll.gameObject.tag == "Food") 
//		{
//			collectedObjects.Add (coll.gameObject);
//			ScoreController.scoreCount++;
//		}
//	}
//
//	void OnCollisionExit2D(Collision2D coll) 
//	{
//		if (coll.gameObject.tag == "Food") 
//		{
//			collectedObjects.Remove (coll.gameObject);
//			ScoreController.scoreCount--;
//		}
//	}

	void OnTriggerEnter2D(Collider2D coll) 
	{
		if (coll.gameObject.tag == "Food") 
		{
			collectedObjects.Add (coll.gameObject);
			ScoreController.scoreCount+=2;
		}
		print ("hit");
	}
	
	void OnTriggerExit2D(Collider2D coll) 
	{
		if (coll.gameObject.tag == "Food") 
		{
			collectedObjects.Remove (coll.gameObject);
			ScoreController.scoreCount-=2;
		}
	}
}
