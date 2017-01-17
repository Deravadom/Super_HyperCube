using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 20f;
	public Camera cam;

	private Vector3 camOffset;
	private Rigidbody rigidBody;


	// Use this for initialization
	void Start () {
		rigidBody = this.GetComponent<Rigidbody> ();
		camOffset = cam.transform.position - this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		playerMovement ();
		updateCamera ();
	}

	private void playerMovement() {
		Vector3 newVelocity = rigidBody.velocity;
		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
			//rigidBody.velocity = new Vector3 (rigidBody.velocity.x, rigidBody.velocity.y, speed);
			newVelocity.z = speed;
		if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
			//rigidBody.velocity = new Vector3 (rigidBody.velocity.x, rigidBody.velocity.y, -speed);
			newVelocity.z = -speed;
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
			//rigidBody.velocity = new Vector3 (-speed, rigidBody.velocity.y, rigidBody.velocity.z);
			newVelocity.x= -speed;
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
			//rigidBody.velocity = new Vector3 (speed, rigidBody.velocity.y, rigidBody.velocity.z);
			newVelocity.x = speed;
		/*if (Input.GetKey (KeyCode.Space) && IsOnGround())
			rigidBody.velocity = new Vector3 (rigidBody.velocity.x, jumpForce, rigidBody.velocity.z);*/
		if (Input.GetKey (KeyCode.Space)) {
			//rigidBody.velocity = new Vector3 (rigidBody.velocity.x, speed, rigidBody.velocity.z);
			newVelocity.y = speed;
		}
		if(Input.GetKey(KeyCode.LeftShift)) {
			//rigidBody.velocity = new Vector3 (rigidBody.velocity.x, -speed + UnityEngine.Physics.gravity.z, rigidBody.velocity.z);
			newVelocity.y = -speed + UnityEngine.Physics.gravity.z;
		}

		rigidBody.velocity = newVelocity;
	}
	private bool IsOnGround() {
		return Physics.Raycast(transform.position, Vector3.down, 0.51f);
	}
	private void updateCamera() {
		cam.transform.position = (this.transform.position + camOffset);
	}
}
