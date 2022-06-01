using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAdsScript : MonoBehaviour
{
    //public bool HasUserConsetWasSet;
    public enum BP { Top, Bottom };
    public BP bannerPosition;
    public static MyAdsScript Instance;
    public enum BT { Normal, Smart };
    public BT bannerType;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        //DontDestroyOnLoad(gameObject);
        Advertisements.Instance.Initialize();

    }

    void Start()
    {
        ShowBanner();
        //if (Advertisements.Instance.UserConsentWasSet())
        //{
        //    HasUserConsetWasSet = true;
        //}
        //else
        //{
        //    HasUserConsetWasSet = false;
        //}
        //if(HasUserConsetWasSet)
        //{
        //    Advertisements.Instance.Initialize();
        //}
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void ShowBanner()
    {
        for (int i = 0; i < Advertisements.Instance.GetBannerAdvertisers().Count; i++)
        {
            if (Advertisements.Instance.GetBannerAdvertisers()[i].advertiserScript.IsBannerAvailable() && Advertisements.Instance.CanShowAds())
            {
                if (bannerPosition == BP.Top)
                {
                    if (bannerType == BT.Normal)
                    {
                        Advertisements.Instance.GetBannerAdvertisers()[i].advertiserScript.ShowBanner(BannerPosition.TOP, BannerType.Banner, null);
                    }
                    else
                    {
                        Advertisements.Instance.GetBannerAdvertisers()[i].advertiserScript.ShowBanner(BannerPosition.TOP, BannerType.SmartBanner, null);
                    }
                }
                else
                {
                    if (bannerType == BT.Normal)
                    {
                        Advertisements.Instance.GetBannerAdvertisers()[i].advertiserScript.ShowBanner(BannerPosition.BOTTOM, BannerType.Banner, null);
                    }
                    else
                    {
                        Advertisements.Instance.GetBannerAdvertisers()[i].advertiserScript.ShowBanner(BannerPosition.BOTTOM, BannerType.SmartBanner, null);
                    }
                }
                
            }
        }
    }
    public void HideBanner()
    {
        Advertisements.Instance.HideBanner();
    }
    public void ShowInterstitial()
    {
        for (int i = 0; i < Advertisements.Instance.GetInterstitialAdvertisers().Count; i++)
        {
            if (Advertisements.Instance.GetInterstitialAdvertisers()[i].advertiserScript.IsInterstitialAvailable() && Advertisements.Instance.CanShowAds())
            {
                Advertisements.Instance.GetInterstitialAdvertisers()[i].advertiserScript.ShowInterstitial(InterstitialClosed);
            }
        }
    }
    //public void ShowAInterstitial()
    //{
    //    gameObject.GetComponent<InstertitialDemo>().ShowInterstitial();
    //}
    public void ShowRewardVideo()
    {
        for (int i = 0; i < Advertisements.Instance.GetRewardedAdvertisers().Count; i++)
        {
            if (Advertisements.Instance.GetRewardedAdvertisers()[i].advertiserScript.IsRewardVideoAvailable())
            {
                Advertisements.Instance.GetRewardedAdvertisers()[i].advertiserScript.ShowRewardVideo(CompleteMethod);
            }
        }
    }
    private void InterstitialClosed(string advertiser)
    {
        if (Advertisements.Instance.debug)
        {
            Debug.Log("Interstitial closed from: " + advertiser + " -> Resume Game ");
            GleyMobileAds.ScreenWriter.Write("Interstitial closed from: " + advertiser + " -> Resume Game ");
        }
    }
    private void CompleteMethod(bool completed, string advertiser)
    {
        if (completed == true)
        {
            //give the reward
            int Score = PlayerPrefs.GetInt("SaqibKaScore", 0);
            Score += 100;
            PlayerPrefs.SetInt("SaqibKaScore", Score);
        }
        else
        {
            //no reward
        }
        //if (Advertisements.Instance.debug)
        //{
        //    Debug.Log("Closed rewarded from: " + advertiser + " -> Completed " + completed);
        //    GleyMobileAds.ScreenWriter.Write("Closed rewarded from: " + advertiser + " -> Completed " + completed);
        //    if (completed == true)
        //    {
        //        //give the reward
        //        int  Score = PlayerPrefs.GetInt("SaqibKaScore", 0);
        //        Score += 100;
        //        PlayerPrefs.SetInt("SaqibKaScore",Score);
        //    }
        //    else
        //    {
        //        //no reward
        //    }
        //}
    }
}
