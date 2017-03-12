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
	void Start () 
	{
		myRigidbody= GetComponent<Rigidbody2D> ();
		speed = 10f;
		jumpDir = new Vector2 (0, 1);
		jumpForce = 6f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetInput ();
	}
	void FixedUpdate()
	{
		Debug.Log (GetComponent<Rigidbody2D> ().velocity);
	}
	void GetInput()
	{

		if (isGrounded) 
		{
			horizontal = Input.GetAxis ("Horizontal");
			if (horizontal != 0) 
			{
				transform.Translate (horizontal * Vector2.right * speed * Time.deltaTime);
			}
			if (Input.GetKeyDown(KeyCode.Space)) 
			{
				GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
				Debug.Log ("oi");
				myRigidbody.AddForce (jumpDir * jumpForce, ForceMode2D.Impulse);
			}
		} 
		else 
		{
			transform.Translate (horizontal * Vector2.right * speed * Time.deltaTime);
		}

	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "ground") 
		{
			speed = 5f;
			isGrounded = true;
			isJumpEmpowered = false;
		}
		if(other.gameObject.tag == "enemy")
		{
			Debug.Log ("enemy");
			myRigidbody.AddForceAtPosition (new Vector2 ((other.gameObject.transform.position.x - transform.position.x)*3, 1f), transform.position);
		}
	}
	void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.tag == "ground") 
		{
			speed = 5f;
			isGrounded = false;
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "ledge") 
		{
			speed = 0;
			isGrounded = true;
			GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePosition;
		}
	}
}