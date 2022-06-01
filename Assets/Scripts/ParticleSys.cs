using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSys : MonoBehaviour
{
    public static ParticleSys instance;
    public GameObject[] particles;
    public GameObject[] Emojies;


    public bool playemoji = false;
    private int counter;

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



    /// <summary>
    /// Responsible for playing  emojies
    /// </summary>
    /// <param name="pos"></param>
    public void CollectParticles(Vector3 pos)
    {
        int rand = Random.Range(0, Emojies.Length);
        
        StartCoroutine(Play(pos, Emojies[rand]));
    }

    private IEnumerator Play(Vector3 pos,GameObject ps)
    {
        yield return new WaitForEndOfFrame();
        if (!playemoji)
        {
            playemoji = true;
            GameObject Ps = Instantiate(ps, transform);
            Ps.transform.position = pos;
            Vibration.Vibrate(100);
            
            yield return new WaitForSeconds(2f);
            Destroy(Ps);
        }

    }


    public void UpgradeFx(Vector3 tan)
    {
        GameObject Ps = Instantiate(particles[0],transform);
       
        Ps.transform.position =tan+transform.up;

        GameObject Ps1 = Instantiate(particles[1],transform);
       
        Ps1.transform.position = tan+transform.up;
        Vibration.Vibrate(100);
        Destroy(Ps, 2f);
        Destroy(Ps1, 2f);
    }
}
