using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class DialogDog3 : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public GameObject dialogueGUI;
    public GameObject dialoguesSystem;
    public Transform dialogueBoxGUI;
    public GameObject capsula3;
    public Text forCountTime;

    public float letterDelay = 0.3f;
    public float letterMultiplier = 0.1f;

    public KeyCode DialogueInput = KeyCode.F;

    public string Names;

    public string[] dialogueLines;

    public bool letterIsMultiplied = false;
    public bool dialogueActive = false;
    public bool dialogueEnded = false;
    public bool outOfRange = true;

    void Start()
    {
    }

    private void FixedUpdate()
    {

    }

    public void EnterRangeOfNPC()
    {
        outOfRange = false;
        dialogueGUI.SetActive(true);
        if (dialogueActive == true)
        {
            dialogueGUI.SetActive(false);
        }
    }

    public void NPCName()
    {
        outOfRange = false;
        dialogueBoxGUI.gameObject.SetActive(true);
        Names = "Страж";
        nameText.text = Names;
        if (Input.GetKeyDown(KeyCode.F))
        {

            if (!dialogueActive)
            {
                dialogueActive = true;
                StartCoroutine(StartDialogue());
            }

        }
        StartDialogue();
    }

    private IEnumerator StartDialogue()
    {
        if (outOfRange == false)
        {
            int dialogueLength = dialogueLines.Length;
            int currentDialogueIndex = 0;

            while (currentDialogueIndex < dialogueLength || !letterIsMultiplied)
            {
                if (!letterIsMultiplied)
                {
                    letterIsMultiplied = true;
                    StartCoroutine(DisplayString(dialogueLines[currentDialogueIndex++]));
                    if (currentDialogueIndex >= dialogueLength)
                    {
                        dialogueEnded = true;
                        ForFullTime.txtTimerFull = float.Parse(forCountTime.text);
                        capsula3.SetActive(false);
                        

                    }
                }
                yield return 0;
            }

            while (true)
            {
                if (Input.GetKeyDown(DialogueInput) && dialogueEnded == false)
                {
                    break;
                }
                yield return 0;
            }
            dialogueEnded = false;
            dialogueActive = false;
            DropDialogue();
            SceneManager.LoadSceneAsync(4);
        }
    }

    private IEnumerator DisplayString(string stringToDisplay)
    {
        if (outOfRange == false)
        {
            int stringLength = stringToDisplay.Length;
            int currentCharacterIndex = 0;

            dialogueText.text = "";

            while (currentCharacterIndex < stringLength)
            {
                dialogueText.text += stringToDisplay[currentCharacterIndex];
                currentCharacterIndex++;

                if (currentCharacterIndex < stringLength)
                {
                    if (Input.GetKey(DialogueInput))
                    {
                        yield return new WaitForSeconds(letterDelay * letterMultiplier);
                    }
                    else
                    {
                        yield return new WaitForSeconds(letterDelay);
                    }
                }
                else
                {
                    dialogueEnded = false;
                    break;
                }
            }
            while (true)
            {
                if (Input.GetKeyDown(DialogueInput))
                {
                    break;
                }
                yield return 0;
            }
            dialogueEnded = false;
            letterIsMultiplied = false;
            dialogueText.text = "";
        }
    }

    public void DropDialogue()
    {
        dialogueGUI.SetActive(false);
        dialogueBoxGUI.gameObject.SetActive(false);

    }

    public void OutOfRange()
    {
        outOfRange = true;
        if (outOfRange == true)
        {
            letterIsMultiplied = false;
            dialogueActive = false;
            StopAllCoroutines();
            dialogueGUI.SetActive(false);
            dialogueBoxGUI.gameObject.SetActive(false);
        }
    }
}
