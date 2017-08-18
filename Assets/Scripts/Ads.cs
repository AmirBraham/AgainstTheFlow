using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class Ads : MonoBehaviour {

/*    [SerializeField]
    string GameID = "1156219";
    public string zoneId;
    public GameObject Yes;
    public  Text GameShopMes;
    bool WantAd;
    string WhoWantsAd;


    // Use this for initialization
    void Start () {
    }
    public void ShowAd ()
    {

        Advertisement.Initialize(GameID, false);
        StartCoroutine(ShowAdWhenReady());
    }

    IEnumerator ShowAdWhenReady()
    {
        while (!Advertisement.IsReady())

            yield return null;
        Advertisement.Show();


    }

   
    IEnumerator WaitForAd ()
    {

        float CurrentTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        yield return null;
        while(Advertisement.isShowing)
        {
            yield return null;
        }


        Time.timeScale = CurrentTimeScale;
    }

    public void WantToSeeAd ()
    {
        WantAd = true;

    }
    void OnGUI()
    {
        if (string.IsNullOrEmpty(zoneId)) zoneId = null;

        Rect buttonRect = new Rect(-279, -125, 240, 104);
        string buttonText = Advertisement.IsReady(zoneId) ? "Show Ad" : "Waiting...";

        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResult;

        if (WantAd)
        {
            Advertisement.Show(zoneId, options);
            WantAd = false;
        }
    }

    public void QuitAdPurchase ()
    {
        GameShopMes.text = "Would you like to watch an ad for a 50 coins ";
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Video completed. User rewarded " +  " 50 coin");
                PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") + 50);
                GameShopMes.text = "You have successfully earned 50 coins ! Want to earn more ? ";
                WantAd = false;

                break;
            case ShowResult.Skipped:
                Debug.LogWarning("Video was skipped.");
                WantAd = false;
                GameShopMes.text = " You skipped the Ad , Please watch the Full ad to earn coins ! ";
                break;
            case ShowResult.Failed:
                Debug.LogError("Video failed to show.");
                GameShopMes.text = " Failed to show ad , try again ?? ";
                WantAd = false;

                break;
        }
    }
*/
}
