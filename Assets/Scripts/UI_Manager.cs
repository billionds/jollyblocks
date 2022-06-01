using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;
    public Pages[] page;
    public Text Counter;
    public Text LevelName;

    

    private void Awake()
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
        #endregion
    }

    private void Start()
    {
        //activate HOME PAGE ID

        ActivatePage(0);
    }

    public void ActivatePage(int pagenumber)
    {
        for(int i=0;i<page.Length;i++)
        {
            page[i].Object.SetActive(false);
        }
        page[pagenumber].Object.SetActive(true);
    }

    public void Settings()
    {
        ActivatePage(1);
    }

    public void Home()
    {
        ActivatePage(0);
    }

    public void OnPause()
    {
        PlayerController.Gamestarted = false;
        PlayerController.instance.MakeKinematic();
        PlayerController.instance.allplaced = false;
        ActivatePage(5);
        
    }

    public void OnPlay()
    {
        PlayerController.Gamestarted = true;
        PlayerController.instance.NotKinematic();
        if(PlayerController.instance.timer>4)
        {
            PlayerController.instance.allplaced = true;
        }
        ActivatePage(4);

    }


    public void ReloadScene()
    {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        SceneManager.LoadScene(0);
    }

}
[System.Serializable]
public class Pages
{
    public string NameofthePage;
    public GameObject Object;
    
}
