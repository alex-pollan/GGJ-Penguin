using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;
	
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
				
		Vector2 movement = new Vector2 (moveHorizontal, -0.5f);
		rigidbody2D.velocity = movement * speed;

		rigidbody2D.AddForce(new Vector2 
		(
			Mathf.Clamp (rigidbody2D.position.x, boundary.xMin, boundary.xMax), 
			0
		), ForceMode2D.Force);
		
		rigidbody2D.rotation = rigidbody2D.velocity.x * tilt;

	}
}
