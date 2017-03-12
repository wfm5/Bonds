using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public Rigidbody2D myRigidbody;

	public Vector2 jumpDir;
	public float jumpForce;

	public float offsetTime = 5f;
	public float nextRegen;

	public bool isGrounded;
	public bool isJumpEmpowered;
	public bool isStunned;
	public float horizontal;
	public float speed;

	public Vector3 tempVec;
	public Vector3 tempRight;
	public Transform childTransform;
	public Transform followerTransform;


	private int health;
	private int maxHealth;

	public float buff;
	// Use this for initialization
	void Start () {		
		myRigidbody= GetComponent<Rigidbody2D> ();
		speed = 10f;
		maxHealth = 2;
		health = maxHealth;
		jumpDir = new Vector2 (0, 1);
		jumpForce = 6f;
		tempRight = Vector3.right * -1;
		childTransform = GameObject.Find ("YinSprite").GetComponent<Transform>();
		followerTransform = GameObject.Find ("EsperSprite").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextRegen && health != maxHealth) {			
			RegenHealth ();
		}
		GetInput ();
		tempVec = new Vector3 (horizontal, 0, 0).normalized;
		buff = Vector3.Dot (tempVec, tempRight);
		if (buff >= 0) {
			return;
		} else {
			childTransform.Rotate (0, 180, 0);
			followerTransform.Rotate (0,180,0);
			tempRight *= -1;
		}
	}
	void FixedUpdate(){
	}
	void GetInput(){
		if (!isStunned) {
			if (isGrounded) {
				horizontal = Input.GetAxis ("LeftJoystickHorizontal");
				if (horizontal != 0) {
					transform.Translate (horizontal * Vector2.right * speed * Time.deltaTime);
				}
				if (Input.GetButtonDown ("A")) {
					//Debug.Log ("oi");
					myRigidbody.AddForce (jumpDir * jumpForce, ForceMode2D.Impulse);
				}
			} else {
				transform.Translate (horizontal * Vector2.right * speed * Time.deltaTime);
			}
		}

	}
	void RegenHealth(){		
		health += 1;
		
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "ground") {
			speed = 5f;
			isGrounded = true;
			isJumpEmpowered = false;
			isStunned = false;
		}
		if(other.gameObject.tag == "enemy"){
			//Debug.Log ("enemy");
			health -= 1;
			jumpDir = new Vector2 (Vector2.Dot(-(Vector2.right*horizontal), other.gameObject.transform.right), 0.5f);
			myRigidbody.AddForce (jumpDir * jumpForce, ForceMode2D.Impulse);
			jumpDir = new Vector2 (0,1);
			isStunned = true;
			nextRegen = Time.time + offsetTime;

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