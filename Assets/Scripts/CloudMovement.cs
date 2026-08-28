using UnityEngine;

public class CloudMovement : MonoBehaviour
{
   [SerializeField] Animator _animatorCloud1;
   [SerializeField] Animator _animatorCloud2;
   [SerializeField] Animator _animatorCloud3;

   private void Awake()
   {
      _animatorCloud1 = GetComponentInChildren<Animator>();
      _animatorCloud2 = GetComponentInChildren<Animator>();
      _animatorCloud3 = GetComponentInChildren<Animator>();
      
      Cloud();
   }

   private void Cloud()
   {
      _animatorCloud1.SetTrigger("CloudFlow");
      _animatorCloud2.SetTrigger("CloudFlow");
      _animatorCloud3.SetTrigger("CloudFlow");
   }
}
