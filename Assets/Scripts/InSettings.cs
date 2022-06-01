using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InSettings : MonoBehaviour
{

    public GameObject Sound;
    public GameObject vibration;
    public GameObject BGM;
    private void OnEnable()
    {
        Initial();
    }


   public void OnSound()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            Sound.SetActive(true);
            PlayerPrefs.SetInt("Sound", 1);


        }
        else
        {

            Sound.SetActive(false);
            PlayerPrefs.SetInt("Sound", 0);

        }
        AudioManager.instance.SetSOund();
    }

    public void OnBgm()
    {
        if (PlayerPrefs.GetInt("Bgm") == 0)
        {
            BGM.SetActive(true);
            PlayerPrefs.SetInt("Bgm", 1);


        }
        else
        {

            BGM.SetActive(false);
            PlayerPrefs.SetInt("Bgm", 0);

        }
        AudioManager.instance.SetBgM();
    }



    public void OnVibration()
    {
        if (PlayerPrefs.GetInt("vibrate") == 0)
        {
            vibration.SetActive(true);
            PlayerPrefs.SetInt("vibrate", 1);

        }
        else
        {

            vibration.SetActive(false);
            PlayerPrefs.SetInt("vibrate", 0);

        }
    }

    public void Initial()
    {

        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            Sound.SetActive(false);

        }
        else
        {

            Sound.SetActive(true);

        }

        if (PlayerPrefs.GetInt("Bgm") == 0)
        {
            BGM.SetActive(false);

        }
        else
        {

            BGM.SetActive(true);

        }


        if (PlayerPrefs.GetInt("vibrate") == 0)
        {
            vibration.SetActive(false);

        }
        else
        {

            vibration.SetActive(true);

        }


    }
}
