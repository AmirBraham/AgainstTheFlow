using UnityEngine;
using System.Collections;

public class GetTheFishBack : MonoBehaviour {
    // Use this for initialization
    GameObject fish;
	void Start () {
	

	}
    static public bool fadeBool = true;
	// Update is called once per frame
	void Update () {

	}


	void OnTriggerEnter2D (Collider2D Col) {
        if (Submarine.shaker == true)
        {
            if (Col.gameObject.tag == "Fishs")
            {
                fish = Col.gameObject;
                Col.gameObject.transform.position = new Vector3(-4.71f, Random.Range(-3f,-4.4f), 0f);

            }
            if (Col.gameObject.tag == "Submarine")
            {
                fadeBool = false;
            }

        }
        else if (Submarine.shaker == false)
        {

        }
    }
}
