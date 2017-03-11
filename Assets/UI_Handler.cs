using UnityEngine;
using System.Collections;

public class UI_Handler : MonoBehaviour {

    public GameObject self;
    //Scale = X_Scale/32 * resolution
    public float X_Scale = 1f;
    public float Y_Scale = 1f;

    // Use this for initialization
    void Start() {
        self = gameObject;
        GameObject[] T = GameObject.FindGameObjectsWithTag("Scalable");
        print("Children: " + T.Length);
        for (int i = 0; i < T.Length; i++)
        {
            print(T[i].name);
                Transform tran = T[i].GetComponent<Transform>();
                tran.localScale *= X_Scale / 512 * Screen.width;
                tran.localScale *= Y_Scale / 512 * Screen.height;
            
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
