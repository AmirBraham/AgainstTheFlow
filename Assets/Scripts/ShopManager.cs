using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class ShopManager : MonoBehaviour {
	public Button SelectionButton;
    public GameObject[] GAMESHOPUI;
	static public float[]SubmarinesPrices=new float[3];
	static public float[]SubmarinesBought=new float[3];
	static public float[]AccesoriesPrices=new float[4];
	static public float[]AccesoriesBought=new float[4];



	// Use this for initialization
	void Start () {
		SubmarinesPrices[0]=50;
		SubmarinesPrices[1]=100;
		SubmarinesPrices[2]=1000;
		AccesoriesPrices[0]=0;
		AccesoriesPrices[1]=100;
		AccesoriesPrices[2]=300;
		AccesoriesPrices[3]=10;

	}
	
	// Update is called once per frame
	void Update () {
		for(int i=0;i<SceneManagerP.SubSum;i++){
			SubmarinesBought[i]=PlayerPrefs.GetFloat("BoughtSub"+i.ToString());
		}
		for(int i=0;i<SceneManagerP.AccesSum;i++){
			AccesoriesBought[i]=PlayerPrefs.GetFloat("BoughtAc"+i.ToString());
		}
	}

    public void QuitPurchase ()
    {
        GAMESHOPUI[1].transform.DOLocalMoveX(-1074f, 1.2f);

    }
	public void OnClicked(){
		if (SceneManagerP.SelectState) {
			if (SubmarinesBought [SceneManagerP.MinSub] == 1) {
				PlayerPrefs.SetFloat ("SelectedSub", SceneManagerP.MinSub);
			} else {
				if (PlayerPrefs.GetFloat ("Money") >= SubmarinesPrices [SceneManagerP.MinSub]) {
					PlayerPrefs.SetFloat ("Money", PlayerPrefs.GetFloat ("Money") - SubmarinesPrices [SceneManagerP.MinSub]);
					PlayerPrefs.SetFloat ("BoughtSub" + SceneManagerP.MinSub.ToString (), 1);
				} else
                {

                    GAMESHOPUI[1].transform.DOLocalMoveX(0f, 1.2f);


                }
			}
		
		} else {
			if (AccesoriesBought [SceneManagerP.MinAcces] == 1) {
				PlayerPrefs.SetFloat ("SelectedAc", SceneManagerP.MinAcces);
			} else {
				if (PlayerPrefs.GetFloat ("Money") >= AccesoriesPrices [SceneManagerP.MinAcces]) {
					PlayerPrefs.SetFloat ("Money", PlayerPrefs.GetFloat ("Money") - AccesoriesPrices [SceneManagerP.MinAcces]);
					PlayerPrefs.SetFloat ("BoughtAc" + SceneManagerP.MinAcces.ToString (), 1);
				} else
                {

                    GAMESHOPUI[1].transform.DOLocalMoveX(0f, 1.2f);


                }
            }
		}
	}

}
