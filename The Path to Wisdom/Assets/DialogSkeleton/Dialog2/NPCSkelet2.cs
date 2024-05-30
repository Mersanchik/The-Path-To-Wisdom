using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class NPCSkelet2 : MonoBehaviour
{
    public Transform ChatBackGround;
    public Transform NPCCharacter;

    private DialogSkelet2 dialogueSystem;

    public string Name;

    [TextArea(5, 10)]
    public string[] sentences;

    void Start()
    {
        dialogueSystem = FindObjectOfType<DialogSkelet2>();
    }

    void Update()
    {
        Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
        Pos.y -= 160;
        ChatBackGround.position = Pos;
    }

    public void OnTriggerStay(Collider other)
    {
        this.gameObject.GetComponent<NPCSkelet2>().enabled = true;
        FindObjectOfType<DialogSkelet2>().EnterRangeOfNPC();
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F))
        {
            this.gameObject.GetComponent<NPCSkelet2>().enabled = true;
            dialogueSystem.dialogueLines = sentences;
            FindObjectOfType<DialogSkelet2>().NPCName();
        }
    }

    public void OnTriggerExit()
    {
        FindObjectOfType<DialogSkelet2>().OutOfRange();
        this.gameObject.GetComponent<NPCSkelet2>().enabled = false;

    }
}
