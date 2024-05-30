using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitFirstScene : MonoBehaviour
{
    public void Update()//Вернутьтя обратно из любой сцены
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Домой!");
            SceneManager.LoadScene(0);
        }
        
    }
}
