using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using Project.Player;
using UnityEngine.Events;

public class NewNPCForWaves : MonoBehaviour, IInteractable
{
    //Setup für die Hierarchy und Aufbau des Dialoges
    public NPCDialogue dialogueData;
    private DialogueController dialogueUI;
    private int dialogueIndex;
    private bool isTyping, isDialogueActive;

    //Interaction
    private bool isPlayerInRange;
    private PlayerInputManager inputManager;


    [Header("Dialog Events")] public UnityEvent onDialogueEnd;


    private void Awake()
    {
        dialogueUI = DialogueController.Instance;
        inputManager = FindAnyObjectByType<PlayerInputManager>();
    }

    private void Update()
    {
        if (isPlayerInRange && inputManager != null && inputManager.IsInteractPressed)
        {
            Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    public bool CanInteract()
    {
        return !isDialogueActive;
    }


    public void Interact()
    {
        if (dialogueData == null || (PauseController.IsGamePaused && !isDialogueActive))
            return;

        string currentNPC = gameObject.name;
        Debug.Log(currentNPC);

        if (isDialogueActive)
        {
            NextLine();
        }
        else
        {
            StartDialogue();
        }
    }

    public void StartDialogue()
    {
        if (dialogueUI == null)
        {
            dialogueUI = DialogueController.Instance;
        }
        
        StopAllCoroutines();

        isDialogueActive = true;
        dialogueIndex = 0;

        dialogueUI.SetNPCInfo(dialogueData.npcName, dialogueData.npcPortrait); //Neu
        dialogueUI.ShowDialogueUI(true); //Neu
        PauseController.SetPause(true);

        DisplayCurrentLine();
    }

    void NextLine()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueUI.SetDialogueText(dialogueData.dialogueLines[dialogueIndex]); //Neu
            isTyping = false;

            return;
        }

        //Clear Choices
        dialogueUI.ClearChoices();

        //Check endDialogueLines
        if (dialogueData.endDialogueLines.Length > dialogueIndex && dialogueData.endDialogueLines[dialogueIndex])
        {
            EndDialogue();
            return;
        }

        //Check if choices & display
        foreach (DialogueChoice dialogueChoice in dialogueData.choices)
        {
            if (dialogueChoice.dialogueIndex == dialogueIndex)
            {
                DisplayChoices(dialogueChoice);
                return;
            }
        }


        if (++dialogueIndex < dialogueData.dialogueLines.Length)
        {
            DisplayCurrentLine();
        }
        else
        {
            EndDialogue();
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueUI.SetDialogueText(""); //Neu


        foreach (char letter in dialogueData.dialogueLines[dialogueIndex])
        {
            dialogueUI.SetDialogueText(dialogueUI.dialogueText.text += letter); //neu
            yield return new WaitForSeconds(dialogueData.typingSpeed);
        }

        isTyping = false;

        foreach (DialogueChoice dialogueChoice in dialogueData.choices)
        {
            if (dialogueChoice.dialogueIndex == dialogueIndex)
            {
                DisplayChoices(dialogueChoice);
                yield break;
            }
        }

        if (dialogueData.autoProgressLines.Length > dialogueIndex && dialogueData.autoProgressLines[dialogueIndex])
        {
            yield return new WaitForSeconds(dialogueData.autoProgressDelay);
            NextLine();
        }
    }

    void DisplayChoices(DialogueChoice choice)
    {
        for (int i = 0; i < choice.choices.Length; i++)
        {
            int nextIndex = choice.nextDialogueIndexes[i];
            dialogueUI.CreateChoiceButton(choice.choices[i], () => ChooseOption(nextIndex));
        }
    }

    void ChooseOption(int nextIndex)
    {
        if (nextIndex == -1)
        {
            EndDialogue();
            return;
        }

        dialogueIndex = nextIndex;
        dialogueUI.ClearChoices();
        DisplayCurrentLine();
    }

    void DisplayCurrentLine()
    {
        StopAllCoroutines();
        dialogueUI.SetNewPortrait(dialogueData.portraits[dialogueIndex]);
        StartCoroutine(TypeLine());
    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        isDialogueActive = false;
        dialogueIndex = 0;

        dialogueUI.ClearChoices();
        dialogueUI.SetDialogueText("");
        dialogueUI.ShowDialogueUI(false);
        PauseController.SetPause(false);

        onDialogueEnd?.Invoke();
    }
}

//Quelle: https://www.youtube.com/watch?v=eSH9mzcMRqw&t=183s und https://www.youtube.com/watch?v=MPP9GLp44Pc&t=631s
