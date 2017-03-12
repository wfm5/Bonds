using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleClass : MonoBehaviour 
{
	public Vector3 scale;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		scale = transform.localScale;
	}
}
