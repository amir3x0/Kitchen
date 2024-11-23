using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private bool isWalking;
    [SerializeField] private float moveSpeed = 7f;

    private void Update()
    {
        Vector2 inVec = new Vector2(0,0);
        if (Input.GetKey(KeyCode.W)){
            inVec.y += 1;
        }
        if (Input.GetKey(KeyCode.S)){
            inVec.y -= 1;
        }
        if (Input.GetKey(KeyCode.A)){
            inVec.x -= 1;
        }
        if (Input.GetKey(KeyCode.D)){
            inVec.x += 1;
        }
        inVec = inVec.normalized;

        Vector3 movVec = new Vector3(inVec.x, 0f, inVec.y); 
        transform.position += movVec * moveSpeed * Time.deltaTime;

        isWalking = movVec != Vector3.zero;

        transform.forward = Vector3.Slerp(transform.forward, movVec, 0.1f);
    }

    public bool IsWalking(){
        return isWalking;
    }
}

