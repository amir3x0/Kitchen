using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private ClearCounter secondClearCounter; 
    [SerializeField] private bool testing;
    private KitchenObjects kitchenObject;

    private void Update(){
        if (testing && Input.GetKeyDown(KeyCode.T)){
            if(kitchenObject != null){
                kitchenObject.SetClearCounter(secondClearCounter);
                Debug.Log(kitchenObject.GetClearCounter());
            }
        }
    }
    public void Interact()
    {
        if (kitchenObject == null)
        {
            Transform KitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            KitchenObjectTransform.localPosition = Vector3.zero;

            kitchenObject = KitchenObjectTransform.GetComponent<KitchenObjects>();
            kitchenObject.SetClearCounter(this);
        }
        else {
            Debug.Log(kitchenObject.GetClearCounter());
        }

    }

    public Transform GetKitchenObjectFollowTransform(){
        return counterTopPoint;
    }
}