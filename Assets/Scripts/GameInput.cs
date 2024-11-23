using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private void Awake() {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }
    public Vector2 GetMovementVectorNormalized(){
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