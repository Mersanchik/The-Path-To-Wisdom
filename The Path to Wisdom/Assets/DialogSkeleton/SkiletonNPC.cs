using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class SkiletonNPC : MonoBehaviour
{
    public Transform ChatBackGround;
    public Transform NPCCharacter;

    private DialogSkileton dialogueSystem;

    public string Name;

    [TextArea(5, 10)]
    public string[] sentences;

    void Start()
    {
        dialogueSystem = FindObjectOfType<DialogSkileton>();
    }

    void Update()
    {
        Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
        Pos.y -= 160;
        ChatBackGround.position = Pos;
    }

    public void OnTriggerStay(Collider other)
    {
        this.gameObject.GetComponent<SkiletonNPC>().enabled = true;
        FindObjectOfType<DialogSkileton>().EnterRangeOfNPC();
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F))
        {
            this.gameObject.GetComponent<SkiletonNPC>().enabled = true;
            dialogueSystem.dialogueLines = sentences;
            FindObjectOfType<DialogSkileton>().NPCName();
        }
    }

    public void OnTriggerExit()
    {
        FindObjectOfType<DialogSkileton>().OutOfRange();
        this.gameObject.GetComponent<SkiletonNPC>().enabled = false;

    }
}
