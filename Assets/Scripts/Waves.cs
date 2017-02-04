
//Hey couuugi
using UnityEngine;
using System.Collections;

public class Waves : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(new Vector3(0f, 5f, 0f));
        }
	}
}
