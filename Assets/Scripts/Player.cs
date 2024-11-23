using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private bool isWalking;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;

    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 movVec = new Vector3(inputVector.x, 0f, inputVector.y); 
        transform.position += movVec * moveSpeed * Time.deltaTime;

        isWalking = movVec != Vector3.zero;

        transform.forward = Vector3.Slerp(transform.forward, movVec, 0.1f);
    }

    public bool IsWalking(){
        return isWalking;
    }
}

