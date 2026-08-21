using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using Project.Player;

public class NPC : MonoBehaviour, IInteractable
{
    //Setup für die Hierarchy und Aufbau des Dialoges
   public NPCDialogue dialogueData;
   private DialogueController dialogueUI;
   private int dialogueIndex;
   private bool isTyping, isDialogueActive;

   //Interaction
   private bool isPlayerInRange;
   private PlayerInputManager inputManager;
   
   private void Start()
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
    
    if(isDialogueActive)
    {
        NextLine();
    }
    else
    {
        StartDialogue();
    }
}

void StartDialogue()
{
    isDialogueActive = true;
    dialogueIndex = 0;
    
    dialogueUI.SetNPCInfo(dialogueData.npcName, dialogueData.npcPortrait);//Neu
    dialogueUI.ShowDialogueUI(true);//Neu
    PauseController.SetPause(true);

    StartCoroutine(TypeLine());
}

void NextLine()
{
    if (isTyping)
    {  
        StopAllCoroutines();
        dialogueUI.SetDialogueText(dialogueData.dialogueLines[dialogueIndex]);//Neu
        isTyping = false;
    }
    else if(++dialogueIndex < dialogueData.dialogueLines.Length)
    {
        StartCoroutine(TypeLine());
    }
    else
    {
        EndDialogue();
    }
}

 IEnumerator TypeLine()
{
    isTyping = true;
    dialogueUI.SetDialogueText("");//Neu
    
    foreach(char letter in dialogueData.dialogueLines[dialogueIndex])
    {
        dialogueUI.SetDialogueText(dialogueUI.dialogueText.text += letter);//neu
        yield return new WaitForSeconds(dialogueData.typingSpeed);
    }

    isTyping = false;

    if (dialogueData.autoProgressLines.Length > dialogueIndex && dialogueData.autoProgressLines[dialogueIndex])
    {
       yield return new WaitForSeconds(dialogueData.autoProgressDelay);
       NextLine();
    }
}
 public void EndDialogue()
 {
    StopAllCoroutines();
    isDialogueActive = false;
    dialogueUI.SetDialogueText(""); //Neu
    dialogueUI.ShowDialogueUI(false); //Neu
    PauseController.SetPause(false);
 }
}

//Quelle: https://www.youtube.com/watch?v=eSH9mzcMRqw&t=183s und https://www.youtube.com/watch?v=MPP9GLp44Pc&t=631s
