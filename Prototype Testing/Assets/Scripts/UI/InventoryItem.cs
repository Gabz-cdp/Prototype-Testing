using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour
{
    [SerializeField]
    private Image itemImage; //image used to display item //if disabled, hides quantity as well
    [SerializeField]
    private TMP_Text quantityTxt;

    [SerializeField]
    private Image borderImage; //indicates what object is selected

    public event Action<InventoryItem> OnItemClicked, OnItemDroppedOn, OnItemBeginDrag, OnItemEndDrag, OnRightMouseBtnClick; //drag items around and swap them through clicks

    private bool empty = true; //Flag

    public void Awake()
    {
        ResetData();
        Deselect();
    }

    public void ResetData()
    {
        this.itemImage.gameObject.SetActive(false); //Disable image and quantity //Make the slot look empty
        empty = true;
    }

    public void Deselect()
    {
        borderImage.enabled = false; //indicates when a slot is selected
    }

    public void SetData(Sprite sprite, int quantity) //the input data
    {
        this.itemImage.gameObject.SetActive(true);
        this.itemImage.sprite = sprite;
        this.quantityTxt.text = quantity + "";
        this.empty = false; //populated slot
    }

    public void Select()
    {
        borderImage.enabled = true; //indicates the highlighted slot
    }

    public void OnBeginDrag()
    {
        if (empty)
            return; //if the item is empty then you can not drag it
        OnItemBeginDrag?.Invoke(this); //checking to see that there is an item in the slot to be dragged
    }

    public void OnDrop()
    {
        OnItemDroppedOn?.Invoke(this); //when you drop and item on an item it swaps it and rehighlights the slot //will never be empty
    }

    public void OnEndDrag()
    {
        OnItemEndDrag?.Invoke(this);
    }

    public void OnPointerClick(BaseEventData data) //left and right click of mouse
    {
        if (empty)
            return;
        PointerEventData pointerData = (PointerEventData)data;
        if (pointerData.button == PointerEventData.InputButton.Right) //checking which click was used on the mouse
        {
            OnRightMouseBtnClick?.Invoke(this); //right click - other options like feed creature or drop item
        }
        else
        {
            OnItemClicked?.Invoke(this); //left click - select item
        }
    }
}
