using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.IO;

public class OnTrigger : MonoBehaviour {

    EventTrigger trigger;
    public Globals glob;
    public string FileName;
    bool Started = false;
    string buffer = "";
    string[] str_lst;

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
        str_lst = File.ReadAllLines(filename);
        /*
        for (int i = 0; i < str_lst.Length; i++)
        {
            if (str_lst[i].Length > 0)
            {
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.Submit;
                entry.callback.AddListener((data) => { glob.AddToQ(str_lst[i]); } );
            }
        }
        */
    }

    void OnTriggerEnter(Collider col)
    {
        print("Collided");
        if(col.gameObject.name == "Player")
        {
            if (Started == false)
            {
                Started = true;
                for(int i = 0; i < str_lst.Length; i++)
                {
                    glob.AddToQ(str_lst[i]);
                }
                
            }
        }
    }

	// Update is called once per frame
	void Update () {

	}
}
