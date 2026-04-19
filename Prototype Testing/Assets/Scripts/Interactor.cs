using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact(); //Interactive behaviour inherit so the interactor can invoke any specific behaviours
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource; //Stores a reference to a transform in which the interacting ray will be casted
    public float InteractRange; //The length of the interacting ray cast
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) //Interaction key is "E"   
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward); //A ray is cast in the position and direction of the interactive source
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange)) //See if the ray cast detects a collidor
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj)) //Collision information to attempt an interaction eith the object
                {
                    interactObj.Interact();
                }
            }
        }
    }
}
