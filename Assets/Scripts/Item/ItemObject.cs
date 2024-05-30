using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public string GetItemData();
    public void OnInteract();
}

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData itemData;

    public string GetItemData()
    {
        return $"{itemData.Name}\n{itemData.Description}";
    }
    public void OnInteract()
    {
        CharacterManager.Instance.Player.itemData = itemData;
        CharacterManager.Instance.Player.status.UseItem(this);
    }
}
