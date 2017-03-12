using UnityEngine;
using System.Collections;

public class Follower : MonoBehaviour {
	
	public Transform endMarker;
	public float speed = 1.0f;
	public Vector3 offset;
	public float checkRate;
	public float nextCheck;

	public Collider2D[] objects;

	public PlayerController followedChar;

	public enum state {none, ledgeState, moveState};

	public GameObject objectInFocus;
	public Vector3 objectScale;

	public state State;

	// Use this for initialization
	void Start () 
	{	
			
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Debug.Log ("Time: "+Time.time);
		//Debug.Log ("Next Tick: "+nextTick.ToString());
		if (Time.time > nextCheck) 
		{			
			nextCheck = Time.time + checkRate;

			if (followedChar.horizontal == 0)
				checkRate = Random.Range (3f, 5f);
			else
				checkRate = Random.Range (7f, 11f);
			
			RandomizeOffset ();
		}

		transform.position = Vector2.Lerp (transform.position, endMarker.position + offset, speed*Time.deltaTime);

		objects = Physics2D.OverlapCircleAll (transform.position, 5.0f);

		if (State == state.ledgeState) 
		{
			// stay there for a few seconds
			if (objectInFocus && objectInFocus.tag == "ledge") 
			{
				GameObject gobject = objectInFocus.transform.Find ("ledge").gameObject;

				if (gobject.activeSelf == false)
				{
					gobject.SetActive (true);
					State = state.none; // press button to change back state?
				}
			}

			//Debug.Log (objectInFocus + " : " + objectInFocus.tag);
		}

		if (State == state.moveState) 
		{
			if (objectInFocus && objectInFocus.tag == "moveable") 
			{
				objectScale = objectInFocus.GetComponent<ScaleClass> ().scale;
				// find moveable object, get direction it is facing, move it opposite way
				// determing which way object is facing by seeing if its scale is -1 or 1
				if (objectInFocus.GetComponent<ScaleClass>().scale.x < 0) 
				{
					// move it to the right
					objectInFocus.transform.position = new Vector2(objectInFocus.transform.position.x + 1, objectInFocus.transform.position.y);
					State = state.none;
				}

				if (objectInFocus.GetComponent<ScaleClass>().scale.x > 0) 
				{
					// move it to the left
					objectInFocus.transform.position = new Vector2(objectInFocus.transform.position.x - 1 , objectInFocus.transform.position.y);
					State = state.none;
				}
			}
		}
	}
	void RandomizeOffset()
	{
		offset.x = Random.Range(-2f,1f);
		offset.y = Random.Range(0f,1.5f);
	}

	public void GetObjectInFocus(GameObject gObject)
	{
		objectInFocus = gObject;
	}

	private void ClearObjectFromFocus()
	{
		objectInFocus = null;
	}
}
