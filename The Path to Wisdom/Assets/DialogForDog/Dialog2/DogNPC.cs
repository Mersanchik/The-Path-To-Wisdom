using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]

public class DogNPC : MonoBehaviour
{
    public Transform ChatBackGround;
    public Transform NPCCharacter;

    private DialogDog2 dialogueSystem;

    public string Name;

    [TextArea(5, 10)]
    public string[] sentences;

    void Start()
    {
        dialogueSystem = FindObjectOfType<DialogDog2>();
    }

    void Update()
    {
        Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
        Pos.y -= 180;
        ChatBackGround.position = Pos;
    }

    public void OnTriggerStay(Collider other)
    {
        this.gameObject.GetComponent<DogNPC>().enabled = true;
        FindObjectOfType<DialogDog2>().EnterRangeOfNPC();
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F))
        {
            this.gameObject.GetComponent<DogNPC>().enabled = true;
            dialogueSystem.dialogueLines = sentences;
            FindObjectOfType<DialogDog2>().NPCName();
        }
    }

    public void OnTriggerExit()
    {
        FindObjectOfType<DialogDog2>().OutOfRange();
        this.gameObject.GetComponent<DogNPC>().enabled = false;

    }
}
