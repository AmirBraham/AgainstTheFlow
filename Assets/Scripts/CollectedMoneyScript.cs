using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollectedMoneyScript : MonoBehaviour {
	public Text CollectedMoney;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CollectedMoney.text = GameManager.collectedMoneyThisRound.ToString ();
	}
}
