using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Scripting;
using System.Collections.Generic;

public class Globals : MonoBehaviour {

    public GameObject Messager;
    public float delay = 0.3f;
    TextSet textset;
    public string HelloWorld = "Hello World";
    Queue<string> BoxQ = new Queue<string>();
        
	// Use this for initialization
	void Start () {
        textset = (TextSet) Messager.GetComponent("TextSet");
        if ( textset != null)
        {
            textset.SetParams(1, delay, HelloWorld);
        }
	}
	
    public void AddToQ(string str)
    {
        print("Add To Q Called");
        BoxQ.Enqueue(str);
        print(BoxQ.ToArray().ToString());
    }

	// Update is called once per frame
	void Update () {
	    if(textset.isDone)
        { 
            if (BoxQ.Count > 0)
            {
                textset.ClearText();
                textset.SetParams(1, delay, BoxQ.Dequeue());
            }
            
        }
	}
}
