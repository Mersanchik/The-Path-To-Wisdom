using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq.Expressions;
using System.Threading;

public class DialogueSystem: MonoBehaviour {

    public Text nameText;//текстовое поле имя
    public Text dialogueText;//текстовое поле текста

    //система диалога
    public GameObject dialogueGUI;
    public GameObject dialoguesSystem;
    public Transform dialogueBoxGUI;

    //Блок обучения
    public GameObject hand;
    public GameObject BackgroundTeaching;
    public GameObject TextTeaching1;
    public GameObject TextTeachingFirst;
    int countC = 0;

    public GameObject capsule;
    public GameObject stars;

    //скорость с которой должен выводиться текст
    public float letterDelay = 0.3f;
    public float letterMultiplier = 0.1f;

    //клавиша для запуска диалога
    public KeyCode DialogueInput = KeyCode.F;

    //Имя персонажа
    public string Names;

    //массив текстов
    public string[] dialogueLines;

    //Для активации триггеров при диалоге
    public bool letterIsMultiplied = false;
    public bool dialogueActive = false;
    public bool dialogueEnded = false;
    public bool outOfRange = true;


    void Start()
    {
        dialogueText.text = "";
    }

    public void EnterRangeOfNPC()//Диапазон Действия NPC
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
        /*
         * Понажатию на F начинается диалог
         */

        outOfRange = false;
        dialogueBoxGUI.gameObject.SetActive(true);
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
        /*
         * Вывод диалога
         * На определённых индексах говорит тот или иной персонаж
         * Когда диалог заканчивается то первый блок диалога закрывается
         * А если диалог не закончен, то диалог сбрасывается
         */
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
                    if (currentDialogueIndex <= 2)
                    {
                        TextTeachingFirst.SetActive(false);
                        BackgroundTeaching.SetActive(false);
                        Names = "Медведь";
                        nameText.text = Names;
                    }
                    if (currentDialogueIndex >= dialogueLength)
                    {
                        dialogueEnded = true;
                        hand.SetActive(true);
                        stars.SetActive(true);
                        dialogueGUI.SetActive(false);
                        dialoguesSystem.SetActive(false);
                        capsule.SetActive(false);
                        TextTeaching1.SetActive(true);
                        BackgroundTeaching.SetActive(true);
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
        }
    }

    private IEnumerator DisplayString(string stringToDisplay)
    {//отображение диалога побуквенно
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

    public void DropDialogue()//Сброс диалога
    {       
        dialogueGUI.SetActive(false);
        dialogueBoxGUI.gameObject.SetActive(false);
       
    }

    public void OutOfRange()//Если игрог находится дальше капсулы
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
