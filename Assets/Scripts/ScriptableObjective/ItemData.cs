using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Potion
}

public enum PotionItem
{
    Health,
    Skill,
    SpeedUp,
    Exp
}

[CreateAssetMenu(fileName = "ItemData", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Item Info")]
    public string Name;
    public string Description;
    public ItemType Type;
    public string EffectText;

    [Header("Item Prop")]
    public float Recover;

    [Header("Item Potion")]
    public PotionItem PotionType;
}
