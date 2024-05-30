using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timerStart;//переменная с плавающей запятой
    public Text timerTXT;//текстовое поле, где будет отображать значение

    void Start()
    {
        timerTXT.text = timerStart.ToString("F2");
        timerStart = ForFullTime.txtTimerFull;
    }

    void Update()
    {
        timerStart += Time.deltaTime;//к плавающему значению добавляем таймер
        timerTXT.text = timerStart.ToString("F2");//конвертируем в текстовое значение
        //после запятой выделяем 2 значения
    }
}
