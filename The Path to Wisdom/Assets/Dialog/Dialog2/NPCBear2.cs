using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]

public class NPCBear2 : MonoBehaviour
{
    public Transform ChatBackGround;
    public Transform NPCCharacter;

    private DialogBear2 dialogueSystem;

    public string Name;

    [TextArea(5, 10)]
    public string[] sentences;

    void Start()
    {
        dialogueSystem = FindObjectOfType<DialogBear2>();
    }

    void Update()
    {
        Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
        Pos.y -= 160;
        ChatBackGround.position = Pos;
    }

    public void OnTriggerStay(Collider other)
    {
        PickUpStar pickUpStar = new PickUpStar();

        this.gameObject.GetComponent<NPCBear2>().enabled = true;
        FindObjectOfType<DialogBear2>().EnterRangeOfNPC();
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F))
        {
            this.gameObject.GetComponent<NPCBear2>().enabled = true;
            dialogueSystem.dialogueLines = sentences;
            FindObjectOfType<DialogBear2>().NPCName();
        }
    }

    public void OnTriggerExit()
    {
        FindObjectOfType<DialogBear2>().OutOfRange();
        this.gameObject.GetComponent<NPCBear2>().enabled = false;

    }
}
