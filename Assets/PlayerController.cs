using UnityEngine;
using UnityEngine.UI;
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

	public Follower esper;

	public Transform groundCheck;

	// ground check offsets
	Vector2 offsetPos;
	Vector2 offsetPos2;

	// Use this for initialization
	void Start () 
	{
		myRigidbody= GetComponent<Rigidbody2D> ();
		speed = 10f;
		jumpDir = new Vector2 (0, 1);
		jumpForce = 6f;
	
		//esper = GameObject.Find ("Sphere").GetComponent<Follower> ();
		groundCheck = transform.Find ("groundCheck");

		offsetPos = new Vector2 (transform.position.x + 1.5f, transform.position.y);
		//offsetPos2 = 
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetInput ();
	}
	void FixedUpdate()
	{
		isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
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
				myRigidbody.AddForce (jumpDir * jumpForce, ForceMode2D.Impulse);
			}
		} 
		else 
		{
			transform.Translate (horizontal * Vector2.right * speed * Time.deltaTime);
		}

		if (Input.GetKeyDown (KeyCode.RightShift)) 
		{
			// try to check sides later

			for (int i = 0; i < esper.objects.Length; i++)
			{
				// if the first object I get is a ledge
				if (esper.objects [i].gameObject.tag == "ledge") 
				{
					esper.transform.position = esper.objects [i].gameObject.transform.position;

					esper.State = Follower.state.ledgeState;
					esper.GetObjectInFocus (esper.objects [i].gameObject);
				}

				// if the first object I get is moveable
				if(esper.objects[i].gameObject.tag == "moveable")
				{
					esper.transform.position = esper.objects [i].gameObject.transform.position;

					esper.State = Follower.state.moveState;
					esper.GetObjectInFocus (esper.objects [i].gameObject);
				}
			}
		}
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer ("Ground"))
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
		if (other.gameObject.layer == LayerMask.NameToLayer ("Ground")) 
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

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "ledge") 
		{
			speed = 3;
			isGrounded = false;
			GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
		}
	}
}