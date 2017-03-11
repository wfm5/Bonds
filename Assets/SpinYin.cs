using UnityEngine;
using System.Collections;

public class SpinYin : MonoBehaviour {

    public float speed = 0.1f;
    float delay = 0.1f;
    float last_update = 0;
    bool hit_flag = false;
    Vector2 box = new Vector2(1f, 1f);
    Vector3 orig = new Vector3();

    // Use this for initialization
	void Start () {
        last_update = Time.time;
        orig = transform.position;
	}
	
    public void SetHit()
    {
        hit_flag = !hit_flag;
    }

	// Update is called once per frame
	void Update () {
        if( (Time.time - last_update) > delay)
        {
            transform.Rotate(Vector3.forward * speed);
        }
        if(hit_flag)
        {
            Vector2 point = new Vector2();
            point.x = Random.Range(-1f, 1f) * box.x;
            point.y = Random.Range(-1f, 1f) * box.y;
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, orig.x + point.x, Time.deltaTime), Mathf.Lerp(transform.position.y, orig.y + point.y, Time.deltaTime), orig.z);
        }
        
	}
}
