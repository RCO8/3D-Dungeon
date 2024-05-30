using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetItem : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //æ∆¿Ã≈€¿Ã∂˚ √Êµπ«œ∏È ¿⁄µø¿∏∑Œ »πµÊ«œ∞‘
        if (collision.gameObject.TryGetComponent<ItemObject>(out ItemObject item))
        {
            Debug.Log("æ∆¿Ã≈€ »πµÊ");
            Destroy(item.gameObject);
            //»πµÊΩ√ ªÁøÎ
            CharacterManager.Instance.Player.status.UseItem(item);
        }
    }
}
