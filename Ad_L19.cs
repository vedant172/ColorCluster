using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class Ad_L19 : MonoBehaviour
{
    public Text NewtworkText;
    public static Ad_L19 instance;
    private string appID = "ca-app-pub-9330169245374647~9200290913";

    private BannerView bannerView;
    private string bannerID = "ca-app-pub-9330169245374647/6310834231"; //"ca-app-pub-3940256099942544/6300978111";

    private RewardedAd rewarded;
    private string RewardAdId = "ca-app-pub-9330169245374647/6119262543";  //"ca-app-pub-3940256099942544/5224354917";

    //public GameObject ContinuePanel;
    //public GameObject GameOverPanel;
    public Text Continue_score;
    void Start()
    {
        NewtworkText.enabled = false;
        MobileAds.Initialize(initStatus => { });
          this.rewarded = new RewardedAd(RewardAdId);
        this.RequestRewardedAd();

        // Called when an ad request has successfully loaded.
         this.rewarded.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
          this.rewarded.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
            this.rewarded.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
            this.rewarded.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
            this.rewarded.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
         this.rewarded.OnAdClosed += HandleRewardedAdClosed;
        // Start is called before the first frame update
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Update is called once per frame
    public void RequestRewardedAd()
    {
        AdRequest requestR = new AdRequest.Builder().Build();
        rewarded.LoadAd(requestR);
    }

    public void showRewardedAd()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            NewtworkText.enabled = true;
            StartCoroutine(Next_Text_manage());
        }

        else
        {
            if (rewarded.IsLoaded())
            {
                rewarded.Show();
            }

            else
            {
                Debug.Log("video is not loaded");
            }
        }


    }
    private IEnumerator Next_Text_manage()   //ch
    {
        yield return new WaitForSeconds(3);
        NewtworkText.enabled = false;
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }
    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: ");
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
        RequestRewardedAd();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);

        Continue_score.text = "SCORE: " + Main_text10.instance.Score;
        Main_text10.instance.ContinuePanel.SetActive(true);
        Main_text10.instance.GameOverPanel.SetActive(false);
    }
}
