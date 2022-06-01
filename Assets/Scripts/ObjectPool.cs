using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject[] pooledobject;

    private List<GameObject> Square_Pool = new List<GameObject>();
    private List<GameObject> Rectangle_Pool = new List<GameObject>();
    private List<GameObject> Hex_Pool = new List<GameObject>();
    private List<GameObject> Circle_Pool = new List<GameObject>();
    private List<GameObject> Quad_Pool = new List<GameObject>();
    private List<GameObject> Triangle_Pool = new List<GameObject>();
    private List<GameObject> RTriangle_Pool = new List<GameObject>();

    public int maxpool;

    public static ObjectPool instance;

    private void Awake()
    {

        #region Singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
        #endregion
    }


    void Start()
    {       

        for (int i = 0; i < maxpool; i++)
        {
            //Circle
            GameObject obj = (GameObject)Instantiate(pooledobject[0]);
            obj.SetActive(false);
            obj.gameObject.transform.parent = this.transform;
            Circle_Pool.Add(obj);

            //square
            GameObject obj1 = (GameObject)Instantiate(pooledobject[1]);
            obj1.SetActive(false);
            obj1.gameObject.transform.parent = transform;
            Square_Pool.Add(obj1);

            //Rectangle
            GameObject obj2 = (GameObject)Instantiate(pooledobject[2]);
            obj2.SetActive(false);
            obj2.gameObject.transform.parent = this.transform;
            Rectangle_Pool.Add(obj2);

            //Hex
            GameObject obj3 = (GameObject)Instantiate(pooledobject[3]);
            obj3.SetActive(false);
            obj3.gameObject.transform.parent = transform;
            Hex_Pool.Add(obj3);


            //Quad
            GameObject obj4 = (GameObject)Instantiate(pooledobject[4]);
            obj4.SetActive(false);
            obj4.gameObject.transform.parent = transform;
            Quad_Pool.Add(obj4);

            //Triangle
            GameObject obj5 = (GameObject)Instantiate(pooledobject[5]);
            obj5.SetActive(false);
            obj5.gameObject.transform.parent = transform;
            Triangle_Pool.Add(obj3);

            //Reverse Triangle
            GameObject obj6 = (GameObject)Instantiate(pooledobject[6]);
            obj6.SetActive(false);
            obj6.gameObject.transform.parent = transform;
            RTriangle_Pool.Add(obj6);



        }

    }

    /// <summary>
    /// function responosible for Pooling the Squares
    /// </summary>
    /// <returns></returns>
    public GameObject Square_GetPool()
    {
        //checking the availibility of objects that are not active
        for (int i = 0; i < Square_Pool.Count; i++)
        {
            if (!Square_Pool[i].activeInHierarchy)
            {
                return Square_Pool[i];

            }
        }
        //if all are active ,create new one
       
        GameObject obj = (GameObject)Instantiate(pooledobject[1]);
        obj.SetActive(false);
        Square_Pool.Add(obj);
        return obj;
    }

    /// <summary>
    /// function responosible for Pooling the Circles
    /// </summary>
    /// <returns></returns>
    public GameObject Circle_GetPool()
    {
        //checking the availibility of objects that are not active
        for (int i = 0; i < Circle_Pool.Count; i++)
        {
            if (!Circle_Pool[i].activeInHierarchy)
            {
                return Circle_Pool[i];

            }
        }
        //if all are active ,create new one

        GameObject obj = (GameObject)Instantiate(pooledobject[0]);
        obj.SetActive(false);
        Circle_Pool.Add(obj);
        return obj;
    }

    /// <summary>
    /// function responosible for Pooling the Rectangles
    /// </summary>
    /// <returns></returns>
    public GameObject Rectangle_GetPool()
    {
        //checking the availibility of objects that are not active
        for (int i = 0; i < Rectangle_Pool.Count; i++)
        {
            if (!Rectangle_Pool[i].activeInHierarchy)
            {
                return Rectangle_Pool[i];

            }
        }
        //if all are active ,create new one

        GameObject obj = (GameObject)Instantiate(pooledobject[2]);
        obj.SetActive(false);
        Rectangle_Pool.Add(obj);
        return obj;
    }

    /// <summary>
    /// function responosible for Pooling the Hex
    /// </summary>
    /// <returns></returns>
    public GameObject Hex_GetPool()
    {
        //checking the availibility of objects that are not active
        for (int i = 0; i < Hex_Pool.Count; i++)
        {
            if (!Hex_Pool[i].activeInHierarchy)
            {
                return Hex_Pool[i];

            }
        }
        //if all are active ,create new one

        GameObject obj = (GameObject)Instantiate(pooledobject[3]);
        obj.SetActive(false);
        Hex_Pool.Add(obj);
        return obj;
    }

    /// <summary>
    /// function responosible for Pooling the Quad
    /// </summary>
    /// <returns></returns>
    public GameObject Quad_GetPool()
    {
        //checking the availibility of objects that are not active
        for (int i = 0; i < Quad_Pool.Count; i++)
        {
            if (!Quad_Pool[i].activeInHierarchy)
            {
                return Quad_Pool[i];

            }
        }
        //if all are active ,create new one

        GameObject obj = (GameObject)Instantiate(pooledobject[4]);
        obj.SetActive(false);
        Quad_Pool.Add(obj);
        return obj;
    }

    /// <summary>
    /// function responosible for Pooling the Triangles
    /// </summary>
    /// <returns></returns>
    public GameObject Triangle_GetPool()
    {
        //checking the availibility of objects that are not active
        for (int i = 0; i < Triangle_Pool.Count; i++)
        {
            if (!Triangle_Pool[i].activeInHierarchy)
            {
                return Triangle_Pool[i];

            }
        }
        //if all are active ,create new one

        GameObject obj = (GameObject)Instantiate(pooledobject[5]);
        obj.SetActive(false);
        Triangle_Pool.Add(obj);
        return obj;
    }

    /// <summary>
    /// function responosible for Pooling the RTriangles
    /// </summary>
    /// <returns></returns>
    public GameObject RTriangle_GetPool()
    {
        //checking the availibility of objects that are not active
        for (int i = 0; i < RTriangle_Pool.Count; i++)
        {
            if (!RTriangle_Pool[i].activeInHierarchy)
            {
                return RTriangle_Pool[i];

            }
        }
        //if all are active ,create new one

        GameObject obj = (GameObject)Instantiate(pooledobject[6]);
        obj.SetActive(false);
        RTriangle_Pool.Add(obj);
        return obj;
    }


    public GameObject Getpool(int i)
    {
        switch(i)
        {
            case 0:
              return  Circle_GetPool();
                
              
            case 1:
               return Square_GetPool();
                
            case 2:
              return  Rectangle_GetPool();
              

            case 3:
               return Hex_GetPool();
            
            case 4:
               return Quad_GetPool();

              
            case 5:
               return Triangle_GetPool();
              
            case 6:
               return RTriangle_GetPool();
               

            default:

                return null;
        }
    }
}
