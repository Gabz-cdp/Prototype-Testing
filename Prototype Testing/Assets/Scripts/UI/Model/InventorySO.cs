using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu]
    public class InventorySO : ScriptableObject
    {
        //tracks how many items are in inventory and state of items
        [SerializeField]
        private List<InventoryItemSO> inventoryItems; //name of list

        [field: SerializeField]
        public int Size { get; private set; } = 10;

        public event Action<Dictionary<int, InventoryItemSO>> OnInventoryChanged;

        //InventorySO val = null;

        public void Initialize()
        {
            inventoryItems = new List<InventoryItemSO>();
            for (int i = 0; i < Size; i++)
            {
                inventoryItems.Add(InventoryItemSO.GetEmptyItem());
            }
        }

        //InventoryItem item = new InventoryItem();

        //testing
        /*public int AddItem(ItemSO item, int quantity)
        {
            if (item.IsStackable == false)
            {
                for (int i = 0; i < inventoryItems.Count; i++)
                {
                    while (quantity > 0 && IsInventoryFull() == false)
                    {
                        quantity -= AddNonStackableItem(item, 1);
                        //quantity--;
                    }
                    InformAboutChange():
                    return quantity;
                    /*if (inventoryItems[i].IsEmpty)
                    {
                        inventoryItems[i] = new InventoryItemSO
                        {
                            item = item,
                            quantity = quantity
                        };
                        return;
                    }
                }
    }
    quantity = AddStackableItem(item, quantity);
            InformAboutChange();
            return quantity;
        }*/

        private int AddNonStackableItem(ItemSO item, int quantity)
        {
            InventoryItemSO newItem = new InventoryItemSO
            {
                item = item,
                quantity = quantity,
            };

            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].IsEmpty)
                {
                    inventoryItems[i] = newItem;
                    return quantity;
                }
            }
            return 0;
        }

        private bool IsInventoryFull()
            => inventoryItems.Where(item => item.IsEmpty).Any() == false;

        private int AddStackableItem(ItemSO item, int quantity)
        {
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].IsEmpty)
                    continue;
                //if (inventoryItems[i].item.ID == item.ID)
            }
        }

        public void AddItem(InventoryItemSO item)
        {
            //AddItem(item.item, item.quantity);
        }

        public Dictionary<int, InventoryItemSO> GetCurrentInventoryState()
        {
            Dictionary<int, InventoryItemSO> returnValue = new Dictionary<int, InventoryItemSO>();
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].IsEmpty)
                    continue;
                returnValue[i] = inventoryItems[i];
            }
            return returnValue;
        }

        public InventoryItemSO GetItemAt(int itemIndex)
        {
            return inventoryItems[itemIndex];
        }

        public void SwapItems(int itemIndex_1, int itemIndex_2)
        {
            InventoryItemSO item1 = inventoryItems[itemIndex_1];
            inventoryItems[itemIndex_1] = inventoryItems[itemIndex_2];
            inventoryItems[itemIndex_2] = item1;
            InformAboutChange();
        }

        private void InformAboutChange()
        {
            OnInventoryChanged?.Invoke(GetCurrentInventoryState());
        }
    }

    [Serializable] //stores value that isnt easy to modify //struct's cant be null
    public struct InventoryItemSO
    {
        public int quantity;
        public ItemSO item;

        public bool IsEmpty => item == null;

        public InventoryItemSO ChangeQuantity(int newQuantity)
        {
            return new InventoryItemSO
            {
                item = this.item,
                quantity = newQuantity,
            };
        }

        public static InventoryItemSO GetEmptyItem() => new InventoryItemSO
        {
            item = null,
            quantity = 0,
        };
    }
}
