using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private PaddleMover mover;

    void Awake()
    {
        mover = GetComponent<PaddleMover>();
    }

    public void OnMove(CallbackContext context) 
    {
        mover.SetInputVector(context.ReadValue<Vector2>());
    }

    public void OnRotate(CallbackContext context)
    {
        mover.SetRotationVector(context.ReadValue<Vector2>());
    }
}
