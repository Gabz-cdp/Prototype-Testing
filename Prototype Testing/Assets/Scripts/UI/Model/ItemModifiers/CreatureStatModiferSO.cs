using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CreatureStatModifier : ScriptableObject
{
    public abstract void AffectCreature(GameObject character, float val);
}
