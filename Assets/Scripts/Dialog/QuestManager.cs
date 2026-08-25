using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private NPC _npcScript;
    [SerializeField] private NPCDialogue _newDialogue;

    [SerializeField] private NPC _minzyNPC;
    [SerializeField] private GameObject _walterNPC;
    [SerializeField] private GameObject _pennyNPC;
    

    [Header("Quest Items")]
    [SerializeField] public CircleCollider2D _minzysBook;
    [SerializeField] public GameObject _blueberryMuffin;
    [SerializeField] public GameObject _flour;

    private void Update()
    {
        if (_minzysBook == null)
        {
            QuestActivate();
        }
    }

    public void QuestActivate()
    {
            _minzyNPC.dialogueData = _newDialogue;
    }
}
