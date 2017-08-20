using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class GameManager : MonoBehaviour
{
    static public float gameSpeed;
    static public float difficulty;
    static public float fuel;
    static public float score;
    static public float lastScore;
    static public bool canCreatures;
    static public bool canCreateAlgae;
    static public bool SlowDown;
    static public int World;
    static public int lastWorld;
    private float reference = 0.06f;
    private float damageTime;
    private float lastDamage;
    public Image HealthSlider;
    public Text HighScore;
    public static GameObject Player;
    public bool ClickedReplayButton;
    public bool ClickedHomeButton;
    public GameObject GameOver;
    public GameObject gameCanvas;
    public Transform Sun;
    public GameObject SubLight;
    static public float Extrafuel;
    static public float collectedMoney = 0;
    static public float collectedMoneyThisRound = 0;
	private string encHS;
	private string decHS;
	private string encHSC;
	private string decHSC;
	private bool HighScoreSaved;
    public static bool ShrinkedSubmarine;

    // Use this for initialization
    void Awake()
    {
        fuel = 150;
        Extrafuel = fuel;
        damageTime = 0.1f;
        Time.timeScale = 0;
        score = 0;
        lastScore = 0;
        gameSpeed = 3;
        World = 2;
        lastWorld = 2;
        canCreatures = false;
        canCreateAlgae = false;
        SlowDown = false;
        ClickedReplayButton = false;
		collectedMoney = 0;
        Player = GameObject.FindGameObjectWithTag("Player");
        HighScoreSaved = false;
       

    }

    // Update is called once per frame
    void Update()
    {
        CaveMode();
        if (Extrafuel > 150)
        {
            AddMoney();
        }
        UIMANAGER();
        ResetScale();
        /////////////////fuel Clamping
        fuel = Mathf.Clamp(fuel, 0, 150);
        /////////////////Choosing to create Bonuses and Maluses
        if (score > 100) { canCreatures = true; canCreateAlgae = true; }
        ////////////////Invoking functions
        ChooseWorld();
        ///////////Playing Game after first press
        if (Input.GetKey(KeyCode.Space) || Input.touchCount > 0)
        {
            Time.timeScale = 1;

        }

        ///////////
		gameSpeed = Mathf.Clamp(Mathf.Log(2  * Time.timeSinceLevelLoad), 3, 9.5f);
        ////////////Damaging



        //GameOver 
        if (fuel == 0)
        {
            //Displaying GameOver UI
            GameOver.SetActive(true);
            gameCanvas.SetActive(false);
            SaveHighScore();

        }
        else
        {
            if (Time.time - lastDamage > damageTime)
            {
                fuel -= 1f;
                Extrafuel -= 1;
                lastDamage = Time.time;
            }
            score = Time.timeSinceLevelLoad * gameSpeed / 5;
            score = Mathf.Round(score);
        }

    }
    void ChooseWorld()
    {
        if (score - lastScore == 25)
        {
            do
            {
                World = UnityEngine.Random.Range(1, 4);
            } while (World == lastWorld);
            lastScore = score;
            lastWorld = World;

        }
    }
    void ResetScale()
    {
        if(Player != null) {
			if (Player.transform.localScale.x < 0.3f && Player.transform.localScale.y < 0.3)
			{
				Player.transform.localScale = Player.transform.localScale * (1.001f);

			}
        }


    }

    public void Replay()
    {

        SceneManager.LoadScene("Game");
        HighScoreSaved = false;
    }
    public void Home()
    {
        SceneManager.LoadScene("StartScreen");
    }
   
    
    void UIMANAGER()
    {
        //fuel
        HealthSlider.fillAmount = fuel / 150;

        //GameOver
        if (fuel <= 0)
        {
            //GameOver.SetActive(true);
            //gameCanvas.SetActive(false);
            Camera.main.GetComponent<Animator>().SetBool("GameOver", true);
            Camera.main.GetComponent<Grayscale>().enabled = true;

        }



    }

    void SaveHighScore()
    {
        if (SceneManagerP.CaveModeEnabled == false)
        {
            if (HighScoreSaved == false)
            {
                //Verifying if a highscore has already been reached
                if (PlayerPrefs.GetString("encHS") == "")
                {
                    string firstone = Encrypt.EncryptString("0");
                    PlayerPrefs.SetString("encHS", firstone);
                }
                else if (PlayerPrefs.GetString("encHS") != "")
                {
                    decHS = Decrypt.DecryptString(PlayerPrefs.GetString("encHS"));
                    float HSfinal = float.Parse(decHS);

                    //Saving High Score 

                    if (HSfinal < score)
                    {
                        string scoreString = score.ToString();
                        string encS = Encrypt.EncryptString(scoreString);
                        PlayerPrefs.SetString("encHS", encS);
                    }
                }
                if (HighScore != null)
                {
                    decHS = Decrypt.DecryptString(PlayerPrefs.GetString("encHS"));
                    HighScore.text = decHS;
                }
            }
            HighScoreSaved = true;
        }
        if (SceneManagerP.CaveModeEnabled == true)
        {
            if (HighScoreSaved == false)
            {
                //Verifying if a highscore has already been reached
                if (PlayerPrefs.GetString("encHSC") == "")
                {
                    string firstonec = Encrypt.EncryptString("0");
                    PlayerPrefs.SetString("encHSC", firstonec);
                }
                else if (PlayerPrefs.GetString("encHSC") != "")
                {
                    decHSC = Decrypt.DecryptString(PlayerPrefs.GetString("encHSC"));
                    float HSfinalC = float.Parse(decHSC);

                    //Saving High Score 

                    if (HSfinalC < score)
                    {
                        string scoreString = score.ToString();
                        string encSC = Encrypt.EncryptString(scoreString);
                        PlayerPrefs.SetString("encHSC", encSC);
                    }
                    
                }
                if (HighScore != null)
                {
                    decHSC = Decrypt.DecryptString(PlayerPrefs.GetString("encHSC"));
                    HighScore.text = decHSC;
                }
            }
            HighScoreSaved = true;
        }
    }
    void AddMoney()
    {
        collectedMoney = Mathf.Round((Extrafuel - 150f) / 10);
        collectedMoneyThisRound = collectedMoneyThisRound + collectedMoney;
        PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") + collectedMoney);
        Extrafuel = fuel;
//        Debug.Log(PlayerPrefs.GetFloat("Money"));
    }
   void CaveMode()
    {
        if (SceneManagerP.CaveModeEnabled)
        {
            Sun.localRotation = Quaternion.Euler(87.5f, 0, 0);
            SubLight.SetActive(true);
        }

    }
}
