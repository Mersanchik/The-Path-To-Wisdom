using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class NPC : MonoBehaviour {

    public Transform ChatBackGround;//Чат, который бует отображаться на фоне
    public Transform NPCCharacter;//Капсула, которая будет отвечает за героя

    private DialogueSystem dialogueSystem;//Ссылка на скрипт диалога

    [TextArea(5, 10)]
    public string[] sentences;//Переменная для массива предложения

    void Start () {
        dialogueSystem = FindObjectOfType<DialogueSystem>();//Поиск скрипта диалог
    }
	
	void Update () {//обозначаем дальность отображения диалога
          Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
          Pos.y -= 160;
          ChatBackGround.position = Pos;
    }

    public void OnTriggerStay(Collider other)
    {
        this.gameObject.GetComponent<NPC>().enabled = true;
        FindObjectOfType<DialogueSystem>().EnterRangeOfNPC();
        //Если игрок с тэгом "Player" рядом и нажата кнопка "F" - можно начать диалог
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F))
        {
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogueSystem.dialogueLines = sentences;
            FindObjectOfType<DialogueSystem>().NPCName();
        }
    }

    public void OnTriggerExit()
    {
        //Если игрок отходит от капсулы - сбросить диалог
        FindObjectOfType<DialogueSystem>().OutOfRange();
        this.gameObject.GetComponent<NPC>().enabled = false;

    }
}

