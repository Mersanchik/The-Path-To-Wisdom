using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTime : MonoBehaviour
{
    public Text timerTXT;

    void Start()
    {
        timerTXT.text = ForFullTime.txtTimerFull.ToString();
    }
}
