using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTeachForDialog : MonoBehaviour
{
    public GameObject TextTeaching1;
    public GameObject TextTeaching2;
    public GameObject BackgroundTeaching;
    public GameObject hand2;
    int countC=0;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            countC++;
            BackgroundTeaching.SetActive(true);
            TextTeaching2.SetActive(true);
            TextTeaching1.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.C) && countC ==2)
        {
            TextTeaching1.SetActive(false);
            TextTeaching2.SetActive(false);
            BackgroundTeaching.SetActive(false);
            hand2.SetActive(false);
        }
    }
}
