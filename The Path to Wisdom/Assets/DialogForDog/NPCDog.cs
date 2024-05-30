using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]

public class NPCDog : MonoBehaviour
{
    public Transform ChatBackGround;
    public Transform NPCCharacter;

    private DialogDog dialogueSystem;

    public string Name;

    [TextArea(5, 10)]
    public string[] sentences;

    void Start()
    {
        dialogueSystem = FindObjectOfType<DialogDog>();
    }

    void Update()
    {
        Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
        Pos.y -= 180;
        ChatBackGround.position = Pos;
    }

    public void OnTriggerStay(Collider other)
    {
        this.gameObject.GetComponent<NPCDog>().enabled = true;
        FindObjectOfType<DialogDog>().EnterRangeOfNPC();
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F))
        {
            this.gameObject.GetComponent<NPCDog>().enabled = true;
            dialogueSystem.dialogueLines = sentences;
            FindObjectOfType<DialogDog>().NPCName();
        }
    }

    public void OnTriggerExit()
    {
        FindObjectOfType<DialogDog>().OutOfRange();
        this.gameObject.GetComponent<NPCDog>().enabled = false;

    }
}
