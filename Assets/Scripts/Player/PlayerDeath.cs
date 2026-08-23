using Project.Player;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField]
    public GameObject _player;
    
    
    public void TurnOffScripts()
    {
     _player.SetActive(false);
    }
}
