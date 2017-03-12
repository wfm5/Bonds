using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Scripting;
using System.Collections.Generic;

public class Globals : MonoBehaviour {

    public GameObject Messager;
    public float delay;
    public float chat_wait;
    TextSet textset;
    public string HelloWorld = "!";
    Queue<string> BoxQ = new Queue<string>();
    private float last_update;

    // Use this for initialization
    void Start () {
        last_update = Time.time;
        textset = (TextSet) Messager.GetComponent("TextSet");
        if ( textset != null)
        {
            textset.SetParams(1, delay, HelloWorld);
        }
	}
	
    public void AddToQ(string str)
    {
        //print("Add To Q Called");
        BoxQ.Enqueue(str);
        //print(BoxQ.ToArray().ToString());
    }

    // Update is called once per frame
    void Update () {
	    if(textset.isDone)
        {
            if (BoxQ.Count > 0 && (Time.time - last_update) > chat_wait)
            {
                last_update = Time.time;
                string buff = BoxQ.Dequeue();
                textset.ClearText();
                textset.SetParams(1, delay, buff);
            }

        }
	}

    void OnApplicationExit()
    {
       // StopAllCoroutines();
    }
}
