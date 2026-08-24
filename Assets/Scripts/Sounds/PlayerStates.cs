using UnityEngine;

public enum ActionState {Default, Attacking}
public enum MovementState{Idle, Walking, Running}

public class PlayerStates : MonoBehaviour
{
    public static PlayerStates Instance;
    
    [SerializeField] private ActionState actionState;
    
    [SerializeField] private MovementState movementState;
    public MovementState MovementState => movementState;

    private void Awake()
    {
        Instance = this;
    }

    public void SetMovementState(MovementState newMovementState)
    {
        movementState = newMovementState;
    }       

    public ActionState GetCurrentActionState()
    {
        return actionState;
    }
}
