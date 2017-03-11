using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public Rigidbody2D myRigidbody;

	public Vector2 jumpDir;
	public float jumpForce;

	public bool isGrounded;
	public bool isJumpEmpowered;
	public float horizontal;
	public float speed;


	// Use this for initialization
	void Start () {
		myRigidbody= GetComponent<Rigidbody2D> ();
		speed = 10f;
		jumpDir = new Vector2 (0, 1);
		jumpForce = 6f;
	}
	
	// Update is called once per frame
	void Update () {
		GetInput ();

	}
	void FixedUpdate(){
	}
	void GetInput(){

		if (isGrounded) {
			horizontal = Input.GetAxis ("LeftJoystickHorizontal");
			if (horizontal != 0) {
				transform.Translate (horizontal * Vector2.right * speed * Time.deltaTime);
			}
			if (Input.GetButtonDown ("A")) {
				Debug.Log ("oi");
				myRigidbody.AddForce (jumpDir * jumpForce, ForceMode2D.Impulse);
			}
		} else {
			transform.Translate (horizontal * Vector2.right * speed * Time.deltaTime);
		}

	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "ground") {
			speed = 5f;
			isGrounded = true;
			isJumpEmpowered = false;
		}
	}
	void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.tag == "ground") {
			speed = 5f;
			isGrounded = false;
		}
	}
}