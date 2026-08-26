using System;
using Project;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{

    [SerializeField] private NPC _minzyNPC;
    [SerializeField] private NPC _walterNPC;
    [SerializeField] private NPC _pennyNPC;
    [SerializeField] private ItemSlot _itemSlot;

    [Header("New Scriptable Objects Second Talk")] 
    [SerializeField] private NPCDialogue _secondMinzyDialogue;
    [SerializeField] private NPCDialogue _secondWalterDialogue;
    [SerializeField] private NPCDialogue _secondPennyDialogue;
    
    
    [Header("New Scriptable Objects Third Talk")] 
    [SerializeField] private NPCDialogue _thirdMinzyDialogue;
    [SerializeField] private NPCDialogue _thirdWalterDialogue;
    [SerializeField] private NPCDialogue _thirdPennyDialogue;
    
    [Header("Quest Items")]
    [SerializeField] public CircleCollider2D _minzysBook;
    [SerializeField] public GameObject _blueberryMuffin;
    [SerializeField] public GameObject _flour;

    [SerializeField] private Image _itemImage;
    
    [SerializeField] private GameObject _colliderDeactivate;

    private void Awake()
    {
        _minzysBook.enabled = false;
    }

    private void Update()
    {
        if (_minzysBook == null)
        {
            QuestBook();
        }

        if (_flour == null)
        {
            QuestFlour();
        }
        
        if( _blueberryMuffin == null) 
        {
            QuestBlueberryMuffin();
            _itemSlot.lastWalterTalk = true;
        }
        
        
        if (_itemSlot.lastWalterTalk)
        {
            _walterNPC.dialogueData = _secondWalterDialogue;
        }
    }

    public void QuestBook()
    { 
        _minzyNPC.dialogueData = _secondMinzyDialogue;
    }

    private void QuestFlour()
    {
        _minzyNPC.dialogueData = _thirdMinzyDialogue;
        _pennyNPC.dialogueData = _secondPennyDialogue;
    }

    private void QuestBlueberryMuffin()
    {
        _pennyNPC.dialogueData = _thirdPennyDialogue; 
        _walterNPC.dialogueData = _secondWalterDialogue;
    }

    public void QuestField()
    {
        if (_itemSlot.lastWalterTalk)
        {
            _colliderDeactivate.SetActive(false);
        }
    }
}
