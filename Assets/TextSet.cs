using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextSet : MonoBehaviour {

    public int set_pos;
    public float delay = 0.3f;
    public Vector3 one = new Vector3(-1 / 3f, 1 / 3f, 0);
    public Vector3 two = new Vector3(1 / 3f, 1 / 3f, 0);
    public Vector3 three = new Vector3(-1 / 3f, -1 / 3f, 0);
    public Vector3 four = new Vector3(1 / 3f, -1 / 3f, 0);
    public bool isDone = false;
    float last_update;
    Text text;
    RectTransform rect_pos;
    RectTransform bg_pos;
    string buffer = "";
    int flag_set = 0;

	// Use this for initialization
	void Start () {
        last_update = Time.time;
        text = GetComponent <Text> ();
        rect_pos = GetComponent<RectTransform>();
        bg_pos = GameObject.Find("Text_BG").GetComponent<RectTransform>();
        one.x *= Screen.width; one.y *= Screen.height;
        two.x *= Screen.width; two *= Screen.height;
        three.x *= Screen.width; three *= Screen.height;
        four.x *= Screen.width; four *= Screen.height;
   	}

    public void SetParams(int pos, float c_delay, string txt)
    {
        //Debug.Log("Hi");
        delay = c_delay;
        buffer = txt;
        set_pos = pos;
        flag_set = 1;
        isDone = false;
    }

    public void ClearText()
    {
        text.text = "";
    }

    void SetRect()
    {
        if (rect_pos != null)
        {
            //print("Flags & Rect present");
            switch (set_pos)
            {
                case 1:
                    //rect_pos.localPosition = one;
                    bg_pos.localPosition = new Vector3(one.x,one.y,-2);
                    break;
                case 2:
                   // rect_pos.localPosition = two;
                    bg_pos.localPosition = two;
                    break;
                case 3:
                  //  rect_pos.localPosition = three;
                    bg_pos.localPosition = three;
                    break;
                case 4:
                  //  rect_pos.localPosition = four;
                    bg_pos.localPosition = four;
                    break;
                default:
                    break;

            }
        }
    }

    // Update is called once per frame
    void Update () {
        if(flag_set == 1)
        {
            flag_set = 0;
            SetRect();
        }
        if (buffer.Length > 0)
        {
            if ((Time.time - last_update) > delay)
            {
                text.text += buffer[0];
                buffer = buffer.Substring(1);
                last_update = Time.time;
            }
        }
        else
        {
            isDone = true;
        }
        //Debug.Log(rect_pos.position);
    }
}
