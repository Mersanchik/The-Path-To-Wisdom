using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]

public class NPCFinal : MonoBehaviour
{
    public Transform ChatBackGround;
    public Transform NPCCharacter;

    private DialogFinal dialogueSystem;

    public string Name;

    [TextArea(5, 10)]
    public string[] sentences;

    void Start()
    {
        dialogueSystem = FindObjectOfType<DialogFinal>();
    }

    void Update()
    {
        Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
        Pos.y -= 160;
        ChatBackGround.position = Pos;
    }

    public void OnTriggerStay(Collider other)
    {
        this.gameObject.GetComponent<NPCFinal>().enabled = true;
        FindObjectOfType<DialogFinal>().EnterRangeOfNPC();
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F))
        {
            this.gameObject.GetComponent<NPCFinal>().enabled = true;
            dialogueSystem.dialogueLines = sentences;
            FindObjectOfType<DialogFinal>().NPCName();
        }
    }

    public void OnTriggerExit()
    {
        FindObjectOfType<DialogFinal>().OutOfRange();
        this.gameObject.GetComponent<NPCFinal>().enabled = false;

    }
}
