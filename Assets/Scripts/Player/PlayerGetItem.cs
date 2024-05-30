using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetItem : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //�������̶� �浹�ϸ� �ڵ����� ȹ���ϰ�
        if (collision.gameObject.TryGetComponent<ItemObject>(out ItemObject item))
        {
            Debug.Log("������ ȹ��");
            Destroy(item.gameObject);
            //ȹ��� ���
            CharacterManager.Instance.Player.status.UseItem(item);
        }
    }
}
