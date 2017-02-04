using UnityEngine;
using System.Collections;

public class GetTheFishBack2 : MonoBehaviour {
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
				Col.gameObject.transform.position = new Vector3(-4.71f, Random.Range(10f,0f), 0f);

			}
			if (Col.gameObject.tag == "Submarine")
			{
				fadeBool = false;
			}

		}
	}
}
