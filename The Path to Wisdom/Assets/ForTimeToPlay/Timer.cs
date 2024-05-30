using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timerStart;//���������� � ��������� �������
    public Text timerTXT;//��������� ����, ��� ����� ���������� ��������

    void Start()
    {
        timerTXT.text = timerStart.ToString("F2");
        timerStart = ForFullTime.txtTimerFull;
    }

    void Update()
    {
        timerStart += Time.deltaTime;//� ���������� �������� ��������� ������
        timerTXT.text = timerStart.ToString("F2");//������������ � ��������� ��������
        //����� ������� �������� 2 ��������
    }
}
