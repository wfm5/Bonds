using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public Rigidbody2D myRigidbody;

	public Vector2 jumpDir;
	public float jumpForce;

	public bool isGrounded;
	public float speed;


	// Use this for initialization
	void Start () {
		myRigidbody= GetComponent<Rigidbody2D> ();
		speed = 5f;
		jumpDir =new Vector2 (0, 1);
		jumpForce = 5;
	}
	
	// Update is called once per frame
	void Update () {
		GetInput ();
	}
	void FixedUpdate(){
	}
	void GetInput(){
		transform.Translate (new Vector2 (Input.GetAxis ("Horizontal") * speed * Time.deltaTime, 0));
		if (isGrounded) 
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				myRigidbody.AddForce(jumpDir*jumpForce,ForceMode2D.Impulse);
			}
		}	
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "ground") {
			speed = 5f;
			isGrounded = true;
		}
	}
	void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.tag == "ground") {
			speed = .5f;
			isGrounded = false;
		}
	}
}