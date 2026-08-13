using UnityEngine;

public class PauseController : MonoBehaviour
{
    public static bool IsGamedPaused { get; private set; } = false;
    
    public static void SetPause(bool pause)
    {
        IsGamedPaused = pause;
    }
}
