using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour , IKitchenObjectParent
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private ClearCounter secondClearCounter; 
    [SerializeField] private bool testing;
    private KitchenObjects kitchenObject;

    private void Update(){
        if (testing && Input.GetKeyDown(KeyCode.T)){
            if(kitchenObject != null){
                kitchenObject.SetKitchenObjectParent(secondClearCounter);
            }
        }
    }
    public void Interact(Player player)
    {
        Debug.Log("i got here first");
        if (kitchenObject == null)
        {
            Debug.Log("im here");
            Transform KitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            KitchenObjectTransform.GetComponent<KitchenObjects>().SetKitchenObjectParent(this);
        }
        else {
            Debug.Log("kitchen object not null");
            kitchenObject.SetKitchenObjectParent(player);
        }

    }

    public Transform GetKitchenObjectFollowTransform(){
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObjects kitchenObject){
        this.kitchenObject = kitchenObject;
    }

    public KitchenObjects GetKitchenObjects(){
        return kitchenObject;
    }

    public void ClearKitchenObject(){
        kitchenObject = null;
    }

    public bool HasKitchenObject(){
        return kitchenObject != null;
    }
}