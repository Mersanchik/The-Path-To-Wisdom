using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]

public class DogNPC3 : MonoBehaviour
{
    public Transform ChatBackGround;
    public Transform NPCCharacter;

    private DialogDog3 dialogueSystem;

    public string Name;

    [TextArea(5, 10)]
    public string[] sentences;

    void Start()
    {
        dialogueSystem = FindObjectOfType<DialogDog3>();
    }

    void Update()
    {
        Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
        Pos.y -= 160;
        ChatBackGround.position = Pos;
    }

    public void OnTriggerStay(Collider other)
    {
        this.gameObject.GetComponent<DogNPC3>().enabled = true;
        FindObjectOfType<DialogDog3>().EnterRangeOfNPC();
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F))
        {
            this.gameObject.GetComponent<DogNPC3>().enabled = true;
            dialogueSystem.dialogueLines = sentences;
            FindObjectOfType<DialogDog3>().NPCName();
        }
    }

    public void OnTriggerExit()
    {
        FindObjectOfType<DialogDog3>().OutOfRange();
        this.gameObject.GetComponent<DogNPC3>().enabled = false;

    }
}
