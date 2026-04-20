using Inventory.Model;
using Inventory.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField]
        private InventoryPage inventoryUI;

        [SerializeField]
        private InventorySO inventoryData;

        public List<InventoryItemSO> initialItems = new List<InventoryItemSO>();

        //public int inventorySize = 5; //Temp value

        private void Start()
        {
            PrepareUI();
            PrepareInventoryData();
        }

        private void PrepareInventoryData()
        {
            inventoryData.Initialize();
            inventoryData.OnInventoryChanged += UpdateInventoryUI;
            foreach (InventoryItemSO item in initialItems)
            {
                if (item.IsEmpty)
                    continue;
                inventoryData.AddItem(item);
            }
        }

        private void UpdateInventoryUI(Dictionary<int, InventoryItemSO> inventoryState)
        {
            inventoryUI.ResetAllItems();
            foreach (var item in inventoryState)
            {
                inventoryUI.UpdateData(item.Key, item.Value.item.ItemImage, item.Value.quantity);
            }
        }

        private void PrepareUI()
        {
            this.inventoryUI.InitializeInventoryUI(inventoryData.Size);
            this.inventoryUI.OnSwapItems += HandleSwapItems;
            //this.inventoryUI.OnStartDragging += HandleDragging;
            //this.inventoryUI.OnItemActionRequested += HandleItemActionRequest;
        }

        private void HandleSwapItems(int itemIndex_1, int itemIndex_2)
        {

        }

        private void HandleDragging(int itemIndex)
        {
            InventoryItemSO inventoryItem = inventoryData.GetItemAt(itemIndex);
            if (inventoryItem.IsEmpty)
                return;
            inventoryUI.CreateDraggedItem(inventoryItem.item.ItemImage, inventoryItem.quantity);
        }

        private void HandleItemActionRequest(int itemIndex)
        {
            //inventoryData.SwapItems(itemIndex_1, itemIndex_2);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.I)) //Open inventory with the keyboard key "I" (can change) //Alteranative method (Input.GetMouseKeyDown(0))
            {
                if (inventoryUI.isActiveAndEnabled == false) //Changed opening of inventory to a mouse click rather
                {
                    inventoryUI.Show();
                    foreach (var item in inventoryData.GetCurrentInventoryState())
                    {
                        inventoryUI.UpdateData(item.Key, item.Value.item.ItemImage, item.Value.quantity);
                    }
                }
                else
                {
                    inventoryUI.Hide();
                }
            }
        }
    }
}
