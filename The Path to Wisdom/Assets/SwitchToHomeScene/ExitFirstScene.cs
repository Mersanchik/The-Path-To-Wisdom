using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitFirstScene : MonoBehaviour
{
    public void Update()//��������� ������� �� ����� �����
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("�����!");
            SceneManager.LoadScene(0);
        }
        
    }
}
