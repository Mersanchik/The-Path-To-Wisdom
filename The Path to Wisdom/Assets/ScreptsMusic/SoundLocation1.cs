using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SoundLocation1 : MonoBehaviour
{
    [Tooltip("Audio Source Does �ot Connect Automatically")]
    [SerializeField] public AudioSource audio;//�������� �� ����������� ������

    private void FixedUpdate()//��� ���������� ����������� ������
    {
        if (!audio.isPlaying)
        {
            audio.Play();
        }
    }
}
