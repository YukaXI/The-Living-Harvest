using Project.Player;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutSceneTrigger : MonoBehaviour
{
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private PlayableDirector timelineDirector;
        [SerializeField] private NPC meisterNPC;
        
        [SerializeField] private Transform playerTransform; 
        [SerializeField] private Transform baseTransform;
        [SerializeField] private GameObject player;
        
        private bool hasTriggered = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
                if (collision.CompareTag("Player") && !hasTriggered)
                {
                        hasTriggered = true;
                        
                        _playerMovement.enabled = false;
                        
                        _rigidbody2D.linearVelocity = Vector2.zero;
                        
                        timelineDirector.Play();
                }
        }

        public void TeleportToMC()
        {
                if (playerTransform == null || baseTransform == null) return;

                playerTransform.position = baseTransform.position;
             
                baseTransform.localPosition = Vector3.zero;
                
                _playerMovement.enabled = true;
                player.SetActive(true);
        }

        public void TriggerMeisterNPC()
        {
                if (meisterNPC != null)
                {
                        meisterNPC.Interact();
                }
        }

        public void DestroyMeisterNPC()
        {
                Destroy(meisterNPC);
        }

        public void TeleportToField()
        {
                SceneManager.LoadScene("TestSceneForRobin");
        }
}
