using System;
using UnityEngine;

public class MonologManager : MonoBehaviour
{
   [SerializeField] private GameObject monologAreaGM;
   [SerializeField] private NewNPCForWaves monologArea;
   
private void Start()
{
      monologArea.StartDialogue();   
}

public void SetActiveOff()
   {
      monologAreaGM.SetActive(false);
   }
}
