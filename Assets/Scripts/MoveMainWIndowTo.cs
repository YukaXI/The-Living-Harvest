using System;
using UnityEngine;

public class MoveMainWIndowTo : MonoBehaviour
{
   private void Start()
   {
      if (Display.displays.Length > 0) 
      {
         Display.displays[0].Activate();
      }
   }
   
   //QUelle: https://discussions.unity.com/t/start-the-game-always-on-the-main-display/636889/4
}
