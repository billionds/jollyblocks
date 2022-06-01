using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller1 : MonoBehaviour
{
    public GameObject[] Objects;
    public List<GameObject> Holder;

    public int LevelNumber { get; private set; }

    public OrderListed[] Order;
    public int Max;
    public bool Gamestarted;
  
    public int current;
    public bool CanPlace;

    public GameObject remaining;
    public UnityEngine.UI.Text CountTxt;



    public static PlayerContoller1 instance;
    public  bool isDead;
    private bool playOnce;

    public bool  allplaced;
    public float timer;
    private bool waiting;
    [SerializeField]
    private GameObject WinPS;

    private void Awake()
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
            // DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
        #endregion
    }

    private void Start()
    {
        Holder = new List<GameObject>();

        LevelNumber = PlayerPrefs.GetInt("Level");

        if (LevelNumber >= Order.Length)
        {
            LevelNumber %= Order.Length;
        }
        

        for (int i = 0; i < Order[LevelNumber].ListOrder.Count; i++)
        {
            GameObject obj = Instantiate(Objects[Order[LevelNumber].ListOrder[i]]);
            obj.transform.position = transform.position;
            obj.SetActive(false);
            Holder.Add(obj);

        }
        Ui_Manager1.instance.ShowHintImage(LevelNumber);
        Ui_Manager1.instance.LevelName.text = "LEVEL " + (LevelNumber + 1).ToString();
    }

    private void Update()
    {
        if (Gamestarted&&CanPlace)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (current < Holder.Count)
                {
                    if (current < 2)
                    {
                        Ui_Manager1.instance.Tap_Tutorial(false);
                        Ui_Manager1.instance.Tutorials();
                    }
                    Holder[current].SetActive(true);                 
                    CanPlace = false;
                    current++;
                    ParticleSys.instance.playemoji = false;
                  
                    remaining.SetActive(true);
                    CountTxt.text = (Holder.Count - current).ToString();

                }
               
            }           
        }

        if (allplaced&&!isDead)
        {
            if (timer > 4)
            {
                allplaced = false;
                MakeKinematic();
              
               StartCoroutine( Effect());
            }

            Ui_Manager1.instance.Counter.text = Mathf.RoundToInt(4 - timer).ToString();
            timer += Time.deltaTime;
        }
        
    }

    public void Reload()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void check()
    {
        if (current == Holder.Count)
        {
            Gamestarted = false;
            // restart.SetActive(true);
            allplaced = true;
           
        }

    }
    public void MakeKinematic()
    {
        for (int i = 0; i < Holder.Count; i++)
        {
            Holder[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
           
        }
    }

    public void NotKinematic()
    {
        for (int i = 0; i < Holder.Count; i++)
        {
            Holder[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
    }

    public void StartGame()
    {
        Gamestarted = true;
        CanPlace = true;
        playOnce = true;
        isDead = false;

        Ui_Manager1.instance. Tap_Tutorial(true);
        Ui_Manager1.instance.Tut_count = 0;

        for (int i = 0; i < Holder.Count; i++)
        {
            NotKinematic();
            Holder[i].SetActive(false);

            Holder[i].GetComponent<Controller1>().Reset();
            Holder[i].transform.position = this.transform.position;
            Holder[i].transform.rotation = Quaternion.identity;
        }
        AudioManager.instance.IsStarted = true;
        Ui_Manager1.instance.showTitleBg(false);

    }

        public void DidCompleted()
        {
         StartCoroutine(WinCondition());
        }

    IEnumerator WinCondition()
    {
        if (current >= Holder.Count)
        {
            if (!waiting)
            {

                allplaced = true;
                waiting = true;

                yield return new WaitForEndOfFrame();
            
                //MakeKinematic();
                Ui_Manager1.instance.ActivatePage(6);
                check();
                //  Effect();

            }

            Ui_Manager1.instance.Hold_Tutorial(false);
        }
        else
        {
            Ui_Manager1.instance.Tutorials1();
        }
        

    }

    public void PlayGame()
    {
        StartCoroutine(Startgame());
    }


    IEnumerator Startgame()
    {
        Ui_Manager1.instance.ActivatePage(4);
        Ui_Manager1.instance.Tut_count = 0;
        CountTxt.text = (Holder.Count - current).ToString();
        yield return new WaitForSeconds(1f);
     
        ParticleSys.instance.playemoji = false;

        StartGame();
    }

    public void ResetAll()
    {

      for (int i = 0; i < Holder.Count; i++)
      {
            NotKinematic();
            Holder[i].SetActive(false);

           Holder[i].GetComponent<Controller1>().Reset();
          Holder[i].transform.localPosition = this.transform.localPosition;
          Holder[i].transform.rotation = Quaternion.identity;
       

          Gamestarted = false;
          CanPlace = false;
          playOnce = false;
          isDead = false;

          current = 0;
      
          allplaced = false;
          waiting = false;
          timer = 0;

          
            WinPS.SetActive(false);

        }
        Ui_Manager1.instance.ShowHint.SetActive(false);
        Ui_Manager1.instance.HintB.SetActive(true);

    }
    IEnumerator Effect()
    {
       
        WinPS.SetActive(true);
        WinPS.GetComponent<ParticleSystem>().Play();
        AudioManager.instance.onLevel_Blast();
        yield return new WaitForSeconds(0.5f);
        Ui_Manager1.instance.ActivatePage(2);

        AudioManager.instance.onLvelCompletedUi();
MyAdsScript.Instance.ShowInterstitial();
Debug.Log("Interstitial Displayed");
    }

    
    


}
[System.Serializable]
public class OrderListed
{
    public string name;
    public List<int> ListOrder = new List<int>();
}
