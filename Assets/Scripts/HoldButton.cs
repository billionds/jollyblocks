using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldButton : MonoBehaviour
{
    public bool isholding;

    public List<GameObject> HoldImages;

    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnHold()
    {
        if(!isholding)
        {
            image.color = new Color(1, 1, 1, 0);
            

        }
    }
}
