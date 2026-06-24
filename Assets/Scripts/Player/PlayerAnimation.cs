using System;
using Project.Player;
using UnityEngine;

namespace Project
{
    
}

public class PlayerAnimation : MonoBehaviour
{
    private static readonly int AnimatorHash_MovementType = Animator.StringToHash("Movement");
    private static readonly int AnimatorHash_MovementDirX = Animator.StringToHash("dirX");
    private static readonly int AnimatorHash_MovementDirY = Animator.StringToHash("dirY");
    
    [SerializeField]
    private PlayerMovement _playerMovement;

    [SerializeField] 
    private Transform _visualsTransform;
    
    [SerializeField]
    private Animator[] _animators = Array.Empty<Animator>();
    
    private Vector2 _lastMoveDir =  Vector2.zero;
    
    private void Start()
    {
        if (_animators.Length < 1)
            _animators = GetComponentsInChildren<Animator>(true);
    }
    
    private void Update()
    {
        HandleAnimations();
    }

    private void HandleLookDirection(Vector2 moveDir)
    {
        if (moveDir.x < 0)
        {
        _visualsTransform.localEulerAngles = new Vector3(0, 180, 0);
        return;
        }
        
        _visualsTransform.localEulerAngles = new Vector3(0, 0, 0);
    }
    
    private void HandleAnimations()
    {
        Vector2 moveDir = _playerMovement.CurrentMovementDirection;
        UpdateAnimators(AnimatorHash_MovementType, moveDir == Vector2.zero ? 0 : 1);

        if (moveDir != Vector2.zero)
        {
            HandleMovementAnimations(moveDir);
            HandleLookDirection(moveDir);
            _lastMoveDir = moveDir;
            return;
        }
        
        HandleMovementAnimations(_lastMoveDir);
        HandleLookDirection(_lastMoveDir);
    }
    
    private void HandleMovementAnimations(Vector2 moveDir)
    {
        UpdateAnimators(AnimatorHash_MovementDirX, moveDir.x);
        UpdateAnimators(AnimatorHash_MovementDirY, moveDir.y);
    }
    
    
    private void UpdateAnimators(int animationhash, float value)
    {
        foreach (Animator animator in _animators)
            animator.SetFloat(animationhash, value);
    }
}
