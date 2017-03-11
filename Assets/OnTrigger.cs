using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class OnTrigger : MonoBehaviour {

    EventTrigger trigger;
    public string FileName;
    bool Started = false;
    string buffer = "";

	// Use this for initialization
	void Start () {
        trigger = GetComponent<EventTrigger>();
        if (FileName.Length > 0 )
        {
            PopulateEventSystem(FileName);
        }
    }

    void PopulateEventSystem(string filename)
    {

    }

    void OnTriggerEnter(Collider col)
    {
        print("Collided");
        if(col.gameObject.name == "Player")
        {
            if(Started == false)
            {
                Started = true;
                trigger.OnSubmit(null);
            }
        }
    }

	// Update is called once per frame
	void Update () {

	}
}
