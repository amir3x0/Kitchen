using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    private PlayerInputActions playerInputActions;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interact_preformed;

    }

    private void Interact_preformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inVec = playerInputActions.Player.Move.ReadValue<Vector2>();

        // if (Input.GetKey(KeyCode.W)){
        //     inVec.y += 1;
        // }
        // if (Input.GetKey(KeyCode.S)){
        //     inVec.y -= 1;
        // }
        // if (Input.GetKey(KeyCode.A)){
        //     inVec.x -= 1;
        // }
        // if (Input.GetKey(KeyCode.D)){
        //     inVec.x += 1;
        // }

        inVec = inVec.normalized;

        return inVec;
    }
}