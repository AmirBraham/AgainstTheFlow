using UnityEngine;
using UnityEngine.UI;
#if UNITY_ANDROID
using UnityEngine.Advertisements;
#endif
public class Ads : MonoBehaviour
{

    public GameObject Yes;
    public Text GameShopMes;

    [SerializeField]
    private string
     androidGameId = "1517900",
     iosGameId = "1517901";
    string gameId;


	void Start()
	{
		gameId = null;
		#if UNITY_ANDROID
				gameId = androidGameId;
		#elif UNITY_IOS
		                   gameId = iosGameId;
		#endif

		#if UNITY_ANDROID || UNITY_IOS
				Advertisement.Initialize(gameId, true);
				print("Ads Shown");
		#endif
	}
    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("video"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("video", options);
        }
    }

   
    public void QuitAdPurchase()
    {
        GameShopMes.text = "Would you like to watch an ad for a 50 coins ";
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Video completed. User rewarded " + " 50 coin");
                PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") + 50);
                GameShopMes.text = "You have successfully earned 50 coins ! Want to earn more ? ";
                break;
            case ShowResult.Skipped:
                Debug.LogWarning("Video was skipped.");
                GameShopMes.text = " You skipped the Ad , please watch the full ad to earn coins ! ";
                break;
            case ShowResult.Failed:
                Debug.LogError("Video failed to show.");
                GameShopMes.text = " Failed to show ad , try again ? ";
                break;
        }
    }


}
