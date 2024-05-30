using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTeachingTimer : MonoBehaviour
{
    public GameObject hand;
    public GameObject TextTeaching;
    public GameObject BackgroundTeaching;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            BackgroundTeaching.SetActive(false);
            TextTeaching.SetActive(false);
            hand.SetActive(false);
        }
    }
}
