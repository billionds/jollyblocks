using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ui_Manager1 : MonoBehaviour
{
    public static Ui_Manager1 instance;
    public Pages[] page;
    public Text Counter;
    public Text LevelName;

    [SerializeField]
    private GameObject tap;

    [SerializeField]
    private GameObject hold;
    public int Tut_count;

    public List<Sprite> Hints;
    public Image HintImage;
    public GameObject ShowHint;
    public GameObject HintB;

    public GameObject BG_parallax;
    public GameObject Bg_Title;
    public GameObject Boat;
    

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
        if (AudioManager.instance.IsStarted)
        {
            showTitleBg(false);
        }
        else
        {
            showTitleBg(true);

        }
        Home();
    }

    public void ActivatePage(int pagenumber)
    {
        for (int i = 0; i < page.Length; i++)
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
       
        PlayerContoller1.instance.MakeKinematic();
        PlayerContoller1.instance.allplaced = false;
        ActivatePage(5);

    }

    public void OnPlay()
    {
        
        PlayerContoller1.instance.NotKinematic();
        if (PlayerContoller1.instance.timer > 4)
        {
            PlayerContoller1.instance.allplaced = true;
        }
        ActivatePage(4);

    }

    public void ReloadScene()
    {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
      
        SceneManager.LoadScene(0);
    }



    public void Tutorials()
    {
       if(PlayerPrefs.GetInt("Level")==0)
        {
            if (Tut_count < 2)
            {
                Hold_Tutorial(true);
                PlayerContoller1.instance.MakeKinematic();
            }
        }
    }
    public void Tap_Tutorial(bool place)
    {
        tap.SetActive(place);
    }

    public void Hold_Tutorial(bool place)
    {
        hold.SetActive(place);
    }

    public void Tutorials1()
    {
        if (PlayerPrefs.GetInt("Level") == 0)
        {
            Tut_count++;
            if (Tut_count <= 2)
            {
                Hold_Tutorial(true);
                //Tap_Tutorial(true);
            }
        }
    }

    public void Tutorials12()
    {
        if (PlayerPrefs.GetInt("Level") == 0)
        {
            PlayerContoller1.instance.NotKinematic();
            Hold_Tutorial(false);

        }
    }

    public void ShowHintImage(int number)
    {
        HintImage.sprite = Hints[number];
    }

   public void showTitleBg(bool yes)
    {
        BG_parallax.SetActive(!yes);
        Bg_Title.SetActive(yes);
        Boat.SetActive(!yes);
    }


}
