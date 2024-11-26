using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private static string IS_WALKING = "IsWalking";
    [SerializeField] private Player player;
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Update(){
        animator.SetBool(IS_WALKING,player.IsWalking());
    }
}