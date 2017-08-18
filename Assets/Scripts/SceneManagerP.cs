using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins;

public class SceneManagerP : MonoBehaviour {
	public GameObject[] UI;
    public GameObject WaveOne;
    public GameObject WaveTwo;
	static public bool ClickedStartButton;
	public GameObject SubPos;
	public GameObject fadera;
	public Image[] Subs;
	public Image[] Acces;
	public ScrollRect Selector;
	public RectTransform Center;
	public RectTransform Submarines;
	public RectTransform Accessories;
	public Button State;
	static public bool SelectState=false;
    static public bool CaveModeEnabled;
    public float[] distanceSub;
	public float[] distanceAcces;
	static public int SubSum;
	static public int AccesSum;
	static public int MinSub;
	static public int MinAcces;
	public int buttonDistance;
	public bool canSelect=false;
	public float selectedSub;
	public float selectedAcces;
    public bool ClickedOptionsButton;
    void Start()
    {
		Submarines.anchoredPosition = new Vector2 (PlayerPrefs.GetFloat("SelectedSub")*-buttonDistance,Submarines.anchoredPosition.y );
		Accessories.anchoredPosition = new Vector2 (PlayerPrefs.GetFloat("SelectedAc")*-buttonDistance,Accessories.anchoredPosition.y );
		distanceSub = new float[Subs.Length];
		distanceAcces = new float[Acces.Length];
		SubSum= Subs.Length;
		AccesSum = Acces.Length;
		buttonDistance=800;
      
    }

    

    void Update () {
		if(SelectState){
			Selector.content = Submarines;
		}else{
			Selector.content = Accessories;
		}

        for (int i=0; i < distanceSub.Length;i++){
			distanceSub[i]=Mathf.Abs(Center.transform.position.x-Subs[i].transform.position.x);
		}
		float MinDistance = Mathf.Min(distanceSub);
		for (int i=0;i<distanceSub.Length;i++){
			if (distanceSub[i]==MinDistance){
				MinSub = i;
			}
		}
		/////////////////////
		for(int i=0; i < distanceAcces.Length;i++){
			distanceAcces[i]=Mathf.Abs(Center.transform.position.x-Acces[i].transform.position.x);
		}
		float MinDistanceAcces = Mathf.Min(distanceAcces);
		for (int i=0;i<distanceAcces.Length;i++){
			if (distanceAcces[i]==MinDistanceAcces){
				MinAcces = i;
			}
		}

        if (fadera.GetComponent<SpriteRenderer>().color.a == 1)
        {
            SceneManager.LoadScene("Game");
            GetTheFishBack.fadeBool = false;
        }

        	//UIStartTranslation();
        
	}
	public void endDrag(){
		if (canSelect) {
			if (SelectState) {
				SmoothSelectSubs ();

			} else {
				SmoothSelectAc ();
			}
		}
	}
	public void BackButton(){
		canSelect = false;
        UI[1].transform.DOLocalMoveX(24f, 1.2f);
        UI[0].transform.DOLocalMoveX(24f, 1.2f);
        UI[7].transform.DOLocalMoveX(24f, 1.2f);
        UI[2].transform.DOLocalMoveY(3.1f, 1.2f);
        UI[9].transform.DOLocalMoveX(-763f, 1.2f);
        UI[10].transform.DOLocalMoveX(975f, 1.2f);
        UI[11].transform.DOLocalMoveX(670f, 1.2f);
        UI[12].transform.DOLocalMoveY(-1500f, 1.5f);
        UI[13].transform.DOLocalMoveX(1000f, 1.2f);
        UI[14].transform.DOLocalMoveX(-750f, 1.5f);
        UI[15].transform.DOLocalMoveX(1122f, 1.5f);
		Submarines.anchoredPosition = new Vector2 (PlayerPrefs.GetFloat("SelectedSub")*-buttonDistance,Submarines.anchoredPosition.y );
		Accessories.anchoredPosition = new Vector2 (PlayerPrefs.GetFloat("SelectedAc")*-buttonDistance,Accessories.anchoredPosition.y );
    }
    public void StartButton()
    {
        UI[0].transform.DOLocalMoveX(779f, 1.2f);
        UI[1].transform.DOLocalMoveX(-764f, 1.2f);
        UI[7].transform.DOLocalMoveX(779f, 1.2f);
        UI[9].transform.DOLocalMoveX(-350f, 1.2f);
        UI[15].transform.DOLocalMoveX(-540f, 1.2f);
        UI[2].transform.DOLocalMoveY(5.5f, 1.2f);



    }
    public void NormalMode ()
    {

        CaveModeEnabled = false;
        if (GetTheFishBack.fadeBool == true)
        {
            fadera.GetComponent<Animator>().Play("Fader");

        }

        else if (GetTheFishBack.fadeBool == false)
        {
            fadera.GetComponent<Animator>().Play("Fader");

        }
    }




    public void shopButton () {
		canSelect = true;
        UI[0].transform.DOLocalMoveX(779f, 1.2f);
        
        UI[1].transform.DOLocalMoveX(-764f, 1.2f);
        UI[2].transform.DOLocalMoveY(5.5f, 1.2f);
        UI[7].transform.DOLocalMoveX(779f, 1.2f);
        UI[9].transform.DOLocalMoveX(-350f, 1.2f);
        UI[10].transform.DOLocalMoveX(450f, 1.2f);
        UI[11].transform.DOLocalMoveX(270f, 1.2f);
        UI[12].transform.DOLocalMoveY(-730f,1.5f);
        UI[13].transform.DOLocalMoveX(0f, 1.3f);
        UI[14].transform.DOLocalMoveX(24f, 1.2f);
        UI[8].SetActive(true);
	}

	IEnumerator WaitForSeconds() {
		yield return new WaitForSeconds (1);
	}
  
    
    public void CaveMode()
    {
        //UI[0].transform.DOLocalMoveX(726f, 1.2f);
        CaveModeEnabled = true;
        if (GetTheFishBack.fadeBool == true)
        {
            fadera.GetComponent<Animator>().Play("Fader");

        }

        else if (GetTheFishBack.fadeBool == false)
        {
            fadera.GetComponent<Animator>().Play("Fader");

        }
    }


    public void UIStartTranslation ()
    {
        
            
            //Translation buttons
            for (int i = 0; i < 2; i++)
            {
                UI[i].transform.Translate(18f, 0f, 0f);

            }
            UI[7].transform.Translate(18f, 0f, 0f);
            // Translation LOGO Right Cloud
            UI[2].transform.Translate(0.0f, 0.04f, 0f);
            UI[5].transform.Translate(0.05f, 0f, 0f);

            //translate left and middle cloud
            for (int i = 3; i < 5; i++)
            {
                UI[i].transform.Translate(-0.05f, 0f, 0f);
            }
            //

            //
            
            WaveOne.GetComponent<Animator>().enabled = false;
            WaveTwo.GetComponent<Animator>().enabled = false;
            //
        
       

            //Translation buttons
            for (int i = 0; i < 2; i++)
            {
                UI[i].transform.Translate(18f, 0f, 0f);

            }
            UI[7].transform.Translate(18f, 0f, 0f);
            // Translation LOGO Right Cloud
            UI[2].transform.Translate(0.0f, 0.04f, 0f);
            UI[5].transform.Translate(0.05f, 0f, 0f);

            //translate left and middle cloud
            for (int i = 3; i < 5; i++)
            {
                UI[i].transform.Translate(-0.05f, 0f, 0f);
            }
            //

            //

            WaveOne.GetComponent<Animator>().enabled = false;
            WaveTwo.GetComponent<Animator>().enabled = false;
            //
        }
    

	void SmoothSelectSubs (){
		Submarines.DOAnchorPos (new Vector2(MinSub*-buttonDistance,Submarines.anchoredPosition.y),0.5f,false);
	}
	void SmoothSelectAc (){
		Accessories.DOAnchorPos (new Vector2(MinAcces*-buttonDistance,Accessories.anchoredPosition.y),0.5f,false);
	}




    
	public void OnStateButtonClick(){
		Submarines.anchoredPosition = new Vector2 (PlayerPrefs.GetFloat("SelectedSub")*-buttonDistance,Submarines.anchoredPosition.y );
		Accessories.anchoredPosition = new Vector2 (PlayerPrefs.GetFloat("SelectedAc")*-buttonDistance,Accessories.anchoredPosition.y );
		SelectState = !SelectState;	
	}
    

}
