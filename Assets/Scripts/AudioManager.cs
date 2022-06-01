using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField]
    private AudioSource Bgm;

    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip levelComplete;

    [SerializeField]
    private AudioClip levelFailed;

    [SerializeField]
    private AudioClip CelbrationPopUp;
    public bool IsStarted;


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
    // Start is called before the first frame update
    void Start()
    {
       
        SetBgM();
        SetSOund();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBgM()
    {
        if (PlayerPrefs.GetInt("Bgm") == 1)
        {
            Bgm.mute = enabled;
            
        }
        else
        {
            Bgm.mute = !enabled;
            
        }
    }

    public void SetSOund()
    {
        if (PlayerPrefs.GetInt("Sound") == 1)
        {
          
            source.mute = enabled;
            for (int i = 0; i < PlayerContoller1.instance.Holder.Count; i++)
            {
                PlayerContoller1.instance.Holder[i].gameObject.GetComponent<AudioSource>().mute = enabled;
            }
        }
        else
        {
           
            source.mute = !enabled;

            
            for (int i = 0; i < PlayerContoller1.instance.Holder.Count; i++)
            {
                PlayerContoller1.instance.Holder[i].gameObject.GetComponent<AudioSource>().mute = !enabled;
            }
        }
    }

    public void onLevel_Blast()
    {
        source.PlayOneShot(CelbrationPopUp);
       //source.PlayDelayed(3f);
       // source.PlayOneShot(levelComplete);

    }
    public void  onLvelCompletedUi()
    {
      
        source.PlayOneShot(levelComplete);
    }
    
    public void onLevelFailed()
    {
        source.PlayOneShot(levelFailed);
    }

}
