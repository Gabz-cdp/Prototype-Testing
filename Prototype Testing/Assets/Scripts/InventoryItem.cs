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
    private Image StoredItem; //image used to display item //if disabled, hides quantity as well
    [SerializeField]
    private TMP_Text ItemText;

    [SerializeField]
    private Image border; //indicates what object is selected

    public event Action<InventoryItem> OnItemClicked, OnItemDroppedOn, OnItemBeginDrag, OnItemEndDrag, OnRightMouseBtnClick; //drag items around and swap them through clicks

    private bool empty = true; //Flag

    public void Awake()
    {
        ResetData();
        Deselect();
    }

    public void ResetData()
    {
        this.StoredItem.gameObject.SetActive(false);
        empty = true;
    }

    public void Deselect()
    {
        border.enabled = false;
    }

    public void SetData(Sprite sprite, int quantity)
    {
        this.StoredItem.gameObject.SetActive(true);
        this.StoredItem.sprite = sprite;
        this.ItemText.text = quantity + "";
        this.empty = false;
    }

    public void Select()
    {
        border.enabled = true; //indicates the highlighted slot
    }

    public void OnBeginDrag()
    {
        if (empty)
            return;
        OnItemBeginDrag?.Invoke(this); //checking to see that there is an item in the slot to be dragged
    }

    public void OnDrop()
    {
        OnItemDroppedOn?.Invoke(this);
    }

    public void OnEndDrag()
    {
        OnItemEndDrag?.Invoke(this);
    }

    public void OnPointerClick(BaseEventData data) //left and right click of mouse
    {
        PointerEventData pointerData = (PointerEventData)data;
        if (pointerData.button == PointerEventData.InputButton.Right) //checking which click was used on the mouse
        {
            OnRightMouseBtnClick?.Invoke(this); //right click - other options
        }
        else
        {
            OnItemClicked?.Invoke(this); //left click
        }
    }
}
