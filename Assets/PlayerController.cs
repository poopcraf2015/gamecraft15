using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float Speed = 5f;
	public float Gravity = 1f;
	public CharacterController charController;
	public float JumpDelay = 0.35f;
	public float JumpHeight = 4f;
	//private Rigidbody rb;

	private int horizontal = 0;
	private bool isJumping = false;

	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody>();
	}

	// Every frame
	void Update () {
		if (Input.GetAxis ("Horizontal") < 0)
			horizontal = -1;
		else if (Input.GetAxis ("Horizontal") > 0)
			horizontal = 1;
		else 
			horizontal = 0;

		if (Input.GetKeyDown (KeyCode.UpArrow) && !isJumping) {
			isJumping = true;
			StartCoroutine(jumpingWait());
		}

		float moveFactor = Speed * Time.deltaTime * 10f;
		movePlayer (moveFactor);

	}

	private void movePlayer(float moveFactor) {
		Vector3 trans = Vector3.zero;
		trans = new Vector3 (horizontal * moveFactor, -Gravity * moveFactor, 0f);
		if (isJumping) {
			transform.Translate (Vector3.up * JumpHeight * Time.deltaTime);
		}
		charController.SimpleMove (trans);
	}

	public IEnumerator jumpingWait()
	{
		yield return new WaitForSeconds (JumpDelay);
		isJumping = false;
	}

}
