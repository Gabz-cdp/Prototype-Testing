using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private InventoryPage inventoryUI;
    public int inventorySize = 10; //Temp value

    private void Start()
    {
        inventoryUI.InitializeInventoryUI(inventorySize);
    }
    
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) //Open inventory with the keyboard key "I" (can change)
        {
            if (inventoryUI.isActiveAndEnabled == false) //Changed opening of inventory to a mouse click rather
            {
                inventoryUI.Show();
            }
            else
            {
                inventoryUI.Hide();
            }
        }
    }
}
