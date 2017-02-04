using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectBuyButton : MonoBehaviour {
	//public Button BuySelectButt;
	public Text BuySelectText;
	public Sprite[] ButtonSprites;
	public Image ButtonImage;
	private string ButtonState;
	private bool ButtonIsUp =true;
	// Use this for initialization
	void Start () {
		ButtonImage.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if(ButtonIsUp){
		switch (ButtonState) {
		case "Select":
			ButtonImage.sprite =  ButtonSprites[0];
			
			break;
		case "Selected":
			ButtonImage.sprite =  ButtonSprites[2];
			
			break;
		case "Buy":
			ButtonImage.sprite =  ButtonSprites[4];
			
			break;
		}
		}
		if (SceneManagerP.SelectState) {
			if (PlayerPrefs.GetFloat ("BoughtSub" + SceneManagerP.MinSub.ToString ()) == 1) {
				if (PlayerPrefs.GetFloat ("SelectedSub") == SceneManagerP.MinSub) {
					BuySelectText.text = "Selected";
					ButtonState="Selected";
				} else {
					BuySelectText.text = "Select";
					ButtonState="Select";

				}
			} else {
				BuySelectText.text = "Buy for " + ShopManager.SubmarinesPrices [SceneManagerP.MinSub];
				ButtonState="Buy";

			}
		} else {
			if (PlayerPrefs.GetFloat ("BoughtAc" + SceneManagerP.MinAcces.ToString ()) == 1) {
				if (PlayerPrefs.GetFloat ("SelectedAc") == SceneManagerP.MinAcces) {
					BuySelectText.text = "Selected";
					ButtonState="Selected";

				} else {
					BuySelectText.text = "Select";
					ButtonState="Select";

				}
			} else {
				BuySelectText.text = "Buy for " + ShopManager.AccesoriesPrices [SceneManagerP.MinAcces];
				ButtonState="Buy";

			}
		}
	}
	public void OnTouchDown(){
		ButtonIsUp = false;
		switch (ButtonState) {
		case "Select":
			ButtonImage.sprite =  ButtonSprites[1];
			break;
		case "Selected":
			ButtonImage.sprite =  ButtonSprites[3];

			break;
		case "Buy":
			ButtonImage.sprite =  ButtonSprites[5];

			break;
		}
			
	}
	public void OnTouchUp(){
		ButtonIsUp = true;
	}
}
