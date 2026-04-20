using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
namespace Inventory.Model
{
    [CreateAssetMenu]
    public class EdibleItemSO : ItemSO, IDestroyableItem, IItemAction
    {
        [SerializeField]
        private List<ModifierData> modifiersData = new List<ModifierData>();
        
        public string ActionName => "Feed";
        public AudioClip actionSFX => {get; private set;}
        bool PerformAction(GameObject character)
        {
            foreach (ModifierData data in modifiersData)
            {
                data.statModifier.AffectCreature(character,data.value);
            }
            return true;
        }
    }

    public interface IDestroyableItem
    {

    }

    public interface IItemAction
    {
        public string ActionName { get; }
        public AudioClip actionSFX { get; }
        bool PerformAction(GameObject character, List<ItemParameter> itemState)
    }

[Serializable]
public class ModifierData
{
    public CreatureStatModifierSO statModifier;
    public float value;
}
}*/
