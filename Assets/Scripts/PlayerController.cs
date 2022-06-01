using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] Objects;
    public List<int> order=new List<int>();

    public OrderList1[] Order;

    private List<GameObject> placeaableObjects;

    public static bool isHolding = false;
    public static bool isPlaced = false;
    public static bool isdead = false;
    private int current;

    public static PlayerController instance;
    public static bool Gamestarted = false;

    public bool waiting = false;
    public int LevelNumber;

    public GameObject stick;
    private Vector3 stickTrans;
    public bool allplaced;

    public float timer;

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


    // Start is called before the first frame update
    void Start()
    {
        LevelNumber = PlayerPrefs.GetInt("Level");
        UI_Manager.instance.LevelName.text = "LEVEL " + (LevelNumber+1).ToString();
        stickTrans = stick.transform.position;
        placeaableObjects = new List<GameObject>();
        placeaableObjects.Clear();
        isHolding = false;
        isPlaced = true;
        Gamestarted = false;
        allplaced = false;
        current = 0;
        timer = 0;

        if(LevelNumber>=Order.Length)
        {
            LevelNumber %= Order.Length;
        }
        for (int i = 0; i < Order[LevelNumber].ListOrder.Count; i++)
        {
           
           {
              // GameObject obj = Instantiate(Objects[order[i]]);

             
                GameObject obj = Instantiate(Objects[Order[LevelNumber].ListOrder[i]]);
                obj.transform.position = transform.position;
               obj.SetActive(false);
               placeaableObjects.Add(obj);
             
           }

            //{
            //    GameObject obj1 = ObjectPool.instance.Getpool(order[i]);
            //    obj1.transform.position = transform.position;
              
            //    placeaableObjects.Add(obj1);

            //}


        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!isdead && Gamestarted)
        {
            if (Input.GetMouseButtonDown(0) && !isHolding && isPlaced&&!allplaced)
            {
                if (current < order.Count)
                {
                    placeaableObjects[current].SetActive(true);
                    isPlaced = false;
                    current++;
                    ParticleSys.instance.playemoji = false;
                }
            }  
            if (allplaced)
            {
                if (timer > 4)
                {
                    allplaced = false;

                    if (!isdead)
                    {
                        MakeKinematic();
                        UI_Manager.instance.ActivatePage(2);
                    }
                }


                UI_Manager.instance.Counter.text = Mathf.RoundToInt(5 - timer).ToString();
                timer += Time.deltaTime;
            }
        }
    }

    public void PlayGame()
    {
        StartCoroutine(StartGame());
    }


    IEnumerator StartGame()
    {
        UI_Manager.instance.ActivatePage(4);
        yield return new WaitForSeconds(1f);
        Gamestarted = true;
        if (current < order.Count)
        {
            placeaableObjects[current].SetActive(true);
            isPlaced = false;
            current++;

            ParticleSys.instance.playemoji = false;
        }
    }

    public void DidCompleted()
    {
        StartCoroutine(WinCondition());
    }

    IEnumerator WinCondition()
    {
        if (current == placeaableObjects.Count)
        {
            if (!waiting)
            {
               
                allplaced = true;

                yield return new WaitForEndOfFrame();
                if (!isdead)
                {
                    //MakeKinematic();
                    UI_Manager.instance.ActivatePage(6);
                }
                waiting = true;
            }

        }

    }

    public void MakeKinematic()
    {
        for (int i = 0; i < placeaableObjects.Count; i++)
        {
            placeaableObjects[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        }
    }

    public void NotKinematic()
    {
        for (int i = 0; i < placeaableObjects.Count; i++)
        {
            placeaableObjects[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            placeaableObjects[i].GetComponent<Rigidbody2D>().isKinematic = false;

        }
    }


    public void ResetAll()
    {
        for (int i = 0; i < placeaableObjects.Count; i++)
        {
            placeaableObjects[i].SetActive(false);
           
            placeaableObjects[i].transform.position = transform.position;
            placeaableObjects[i].transform.rotation = Quaternion.identity;
            isHolding = false;
            isPlaced = true;
            Gamestarted = false;
            current = 0;
            isdead = false;
            allplaced = false;
            waiting = false;
            timer = 0;

            stick.SetActive(false);
            stickTrans.y = 4f;
            stick.transform.localPosition= stickTrans;
            stick.transform.
                localRotation= Quaternion.identity;
          
            stick.SetActive(true);
            NotKinematic();

        }
    }
}

[System.Serializable]
public class OrderList1
{
    public string name;
    public List<int>ListOrder = new List<int>();
}
