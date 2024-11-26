using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{

    private bool isWalking;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;

    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 movVec = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerHeight = 2f;
        float playerRadius = .7f;
        bool canMove = !Physics.CapsuleCast(transform.position,transform.position + Vector3.up * playerHeight, playerRadius,  movVec, moveDistance);

        if (!canMove){
            Vector3 moveDirX = new Vector3(movVec.x,0,0).normalized;
            canMove = !Physics.CapsuleCast(transform.position,transform.position + Vector3.up * playerHeight, playerRadius,  moveDirX, moveDistance);

            if (canMove){
                movVec = moveDirX;
            } else {
                Vector3 moveDirZ = new Vector3(0,0,movVec.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position,transform.position + Vector3.up * playerHeight, playerRadius,  moveDirZ, moveDistance);
                if (canMove){
                    movVec = moveDirZ;
                }
            }

        }
        if (canMove)
        {
            transform.position += movVec * moveSpeed * Time.deltaTime;
        }

        isWalking = movVec != Vector3.zero;

        transform.forward = Vector3.Slerp(transform.forward, movVec, 0.1f);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}

