using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MoneyText : MonoBehaviour {
	public Text MoneyT;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		MoneyT.text =PlayerPrefs.GetFloat("Money").ToString ();
	}
}
