using System;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using Project.Player;

public class PlayerFootstepSound : MonoBehaviour
{
    public static Action<FootstepSoundArea, int> OnAreaChange;
    public static Action OnPriorityExit;
    
    [SerializeField] private float footstepTime;
    private float _footstepTimer;

    public List<FootstepSoundArea> _footstepSoundAreas;
    public int _currentPriority = -1;
    
    private StudioEventEmitter _footstepEmitter; // neu hinzugefügt
    private PlayerMovement _playerMovement;
    
    private void Awake()
    {
        _currentPriority = -1;
        _footstepEmitter = GetComponent<StudioEventEmitter>(); // neu hinzugefügt
        _playerMovement = FindAnyObjectByType<PlayerMovement>();
    }

    private void OnEnable()
    {
        OnAreaChange += AreaChange;
        OnPriorityExit += PriorityExit;
    }

    private void OnDisable()
    {
        OnAreaChange -= AreaChange;
        OnPriorityExit -= PriorityExit;
    }

    private void Update()
    { 
        if (_playerMovement.playerMovementState == 0) return;
        if (_footstepSoundAreas.Count < 1) return;
        
        _footstepTimer += Time.deltaTime;
        
        if (_footstepTimer > footstepTime)
        {
            //Debug.Log(_footstepSoundAreas.Count + " " + _currentPriority);
            _footstepTimer = 0;
            _footstepEmitter.Play(); // neu hinzugefügt
            FMOD.RESULT result = _footstepEmitter.EventInstance.setParameterByNameWithLabel("surface", _footstepSoundAreas[_currentPriority].area.ToString()); // neu hinzugefügt
            //print($"Play Sound with event: {_footstepSoundAreas[_currentPriority].fmodFootstepEvent}");
        }
    }
    
    private void AreaChange(FootstepSoundArea footstepSoundArea, int priority)
    {
        if (priority == _currentPriority)
        {
            _footstepSoundAreas[priority] = footstepSoundArea;
            return;
        }
        _currentPriority = priority;
        _footstepSoundAreas.Add(footstepSoundArea);
    }

    private void PriorityExit()
    {
        _footstepSoundAreas.RemoveAt(_currentPriority);
        _currentPriority --;
    }
}
 