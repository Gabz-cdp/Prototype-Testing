using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.UI
{
    public class InventoryPage : MonoBehaviour
    {
        [SerializeField]
        private InventoryItem itemPrefab;

        [SerializeField]
        private RectTransform contentPanel;//Content of the inventory screen

        //[SerializeField]
        //private MouseFollower mouseFollower;

        List<InventoryItem> listOfUIItems = new List<InventoryItem>(); //Stores the indices of each item of the inventory //index of the inventory slots to manage movement of items

        //temp values for testing
        /*public Sprite image, image2; //items
        public int quantity;*/ //item quantity

        private int currentlyDraggedItemIndex = -1; //if minus 1 then out of the bounds of the index //not dragging item
                                                    //right mouse click     //gets info from inventory controller
        //public event Action<int> OnItemActionRequested, OnStartDragging;

        public event Action<int, int> OnSwapItems; //swaps data of both items 

        private void Awake()
        {
            Hide(); //hide the menu
            //mouseFollower.Toggle(false);
        }

        public void InitializeInventoryUI(int inventorysize)
        {
            for (int i = 0; i < inventorysize; i++)
            {
                InventoryItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
                uiItem.transform.SetParent(contentPanel);
                listOfUIItems.Add(uiItem); //Tracks the number of items in the inventory 

                //Assigning methods to the events
                uiItem.OnItemClicked += HandleItemSelection;
                uiItem.OnItemBeginDrag += HandleBeginDrag;
                uiItem.OnItemDroppedOn += HandleSwap;
                uiItem.OnItemEndDrag += HandleEndDrag;
                uiItem.OnRightMouseBtnClick += HandleShowItemActions;
            }
        }

        public void ResetAllItems()
        {
            foreach (var item in listOfUIItems)
            {
                item.ResetData();
                item.Deselect();
            }
        }

        public void UpdateData(int itemIndex, Sprite itemImage, int itemQuantity) //sets the data of the item
        {
            if (listOfUIItems.Count > itemIndex) //wehave this item 
            {
                listOfUIItems[itemIndex].SetData(itemImage, itemQuantity);
            }
        }

        private void HandleItemSelection(InventoryItem inventoryItemUI)
        {
            //Debug.Log(inventoryItemUI.name); //see if items are clickable
            //listOfUIItems[0].Select();

            //the better code
            int index = listOfUIItems.IndexOf(inventoryItemUI);
            if (index == -1)
                return;
        }

        private void HandleBeginDrag(InventoryItem inventoryItemUI)
        {
            int index = listOfUIItems.IndexOf(inventoryItemUI); //returns the index value
            if (index == -1)
                return;
            currentlyDraggedItemIndex = index;
            HandleItemSelection(inventoryItemUI);
            //OnStartDragging?.Invoke(index);
            /*mouseFollower.Toggle(true);
            mouseFollower.SetData(index == 0 ? image : image2, quantity);*/ //change the image(item) depending on the index
        }

        public void CreateDraggedItem(Sprite sprite, int quantity)
        {
            //mouseFollower.Toggle(true);
            //mouseFollower.SetData(sprite, quantity);
        }

        private void HandleSwap(InventoryItem inventoryItemUI)
        {
            int index = listOfUIItems.IndexOf(inventoryItemUI);
            if (index == -1)
            {
                /*mouseFollower.Toggle(false);
                currentlyDraggedItemIndex = -1;*/ //reset the triggers (dont swap if there is nothing there) - nothing will be dragged
                return;
            }
            OnSwapItems?.Invoke(currentlyDraggedItemIndex, index); //does what the code below in green does but better and quicker
            HandleItemSelection(inventoryItemUI);
            /*listOfUIItems[currentlyDraggedItemIndex].SetData(index == 0 ? image : image2, quantity); //checks that the index is 0 and that the images(items) have swapped
            listOfUIItems[index].SetData(currentlyDraggedItemIndex == 0 ? image : image2, quantity);
            mouseFollower.Toggle(false); //hides the mouse follower
            currentlyDraggedItemIndex = -1;*/ //resets item
        }

        private void HandleEndDrag(InventoryItem inventoryItemUI)
        {
            //mouseFollower.Toggle(false);
            ResetDraggedItem();

        }

        private void HandleShowItemActions(InventoryItem inventoryItemUI)
        {

        }

        private void ResetDraggedItem()
        {
            //mouseFollower.Toggle(false);
            currentlyDraggedItemIndex = -1;
        }

        public void ResetSelection()
        {
            DeselectAllItems();
        }

        private void DeselectAllItems()
        {
            foreach (InventoryItem item in listOfUIItems)
            {
                item.Deselect();
            }
        }

        public void Show()
        {
            gameObject.SetActive(true);
            ResetSelection();
            /*listOfUIItems[0].SetData(image, quantity); //the index of the inventory //first item
            listOfUIItems[1].SetData(image2, quantity);*/ //second item
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            ResetDraggedItem();
        }
    }
}
