using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPage : MonoBehaviour
{
    [SerializeField]
    private InventoryItem itemPrefab;

    [SerializeField]
    private RectTransform contentPanel;//Content of the inventory screen

    List<InventoryItem> listOfUIItems = new List<InventoryItem>(); //Stores the indices of each item of the inventory //index of the inventory slots to manage movement of items

    //temp values
    public Sprite image; //item
    public int quantity; //item quantity

    private void Awake()
    {
        Hide(); //hide the menu
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

    private void HandleItemSelection(InventoryItem obj)
    {
        //Debug.Log(obj.name); //see if items are clickable
        listOfUIItems[0].Select();
    }

    private void HandleBeginDrag(InventoryItem obj)
    {
        
    }

    private void HandleSwap(InventoryItem obj)
    {

    }

    private void HandleEndDrag(InventoryItem obj)
    {

    }

    private void HandleShowItemActions(InventoryItem obj)
    {

    }

    public void Show()
    {
        gameObject.SetActive(true);

        listOfUIItems[0].SetData(image, quantity); //the index of the inventory
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
