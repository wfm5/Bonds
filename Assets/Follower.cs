using UnityEngine;
using System.Collections;

public class Follower : MonoBehaviour {
	
	public Transform endMarker;
	public float speed = 1.0f;
	public Vector3 offset;
	public float checkRate;
	public float nextCheck;

	public PlayerController followedChar;

	// Use this for initialization
	void Start () {	
			
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Time: "+Time.time);
		//Debug.Log ("Next Tick: "+nextTick.ToString());
		if (Time.time > nextCheck) {			
			nextCheck = Time.time + checkRate;
			if (followedChar.horizontal == 0)
				checkRate = Random.Range (3f, 5f);
			else
				checkRate = Random.Range (7f, 11f);
			RandomizeOffset ();
		}
		transform.position = Vector2.Lerp (transform.position, endMarker.position + offset, speed*Time.deltaTime);
	}
	void RandomizeOffset(){
		offset.x = Random.Range(-2f,1f);
		offset.y = Random.Range(0f,1.5f);
	}
}
