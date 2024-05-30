using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SoundLocation1 : MonoBehaviour
{
    [Tooltip("Audio Source Does Тot Connect Automatically")]
    [SerializeField] public AudioSource audio;//отвечает за музыкальный ресурс

    private void FixedUpdate()//При кокончании проигрывать заново
    {
        if (!audio.isPlaying)
        {
            audio.Play();
        }
    }
}
