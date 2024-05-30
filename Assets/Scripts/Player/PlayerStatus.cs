using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    //hp, sp, exp
    public StatusUI status;
    Status hp { get => status.hp; }
    Status sp { get => status.sp; }
    Status exp { get => status.exp; }

    public void UseItem(ItemObject item)
    {
        if(item.itemData.Type == ItemType.Potion)
        {
            UsePotion(item);
        }
    }

    private void UsePotion(ItemObject item)
    {
        switch(item.itemData.PotionType)
        {
            case PotionItem.Health:
                //ü�� ȸ��
                CharacterManager.Instance.EffectText.AddonText(item.itemData.EffectText);   //ȿ���� �ؽ�Ʈ��
                hp.Add(item.itemData.Recover);
                break;
            case PotionItem.Skill:
                //��ų ȸ��
                CharacterManager.Instance.EffectText.AddonText(item.itemData.EffectText);
                sp.Add(item.itemData.Recover);
                break;
            case PotionItem.SpeedUp:
                //���� �ð����� ���ǵ� ��
                if(item.gameObject.TryGetComponent<SpeedPotion>(out SpeedPotion speed))
                {
                    //������� ȿ���� ���ÿ� �ؽ�Ʈ ����
                    CharacterManager.Instance.EffectText.AddonText(item.itemData.EffectText, speed.duringTime);
                    StartCoroutine(SpeedUp(speed.AddSpeed, speed.duringTime));
                }
                break;
            case PotionItem.Exp:
                CharacterManager.Instance.EffectText.AddonText(item.itemData.EffectText);
                exp.Add(item.itemData.Recover);
                break;
        }
    }

    IEnumerator SpeedUp(float speed, int time)
    {
        CharacterManager.Instance.Player.controller.moveSpeed *= speed;
        yield return new WaitForSeconds(time);
        CharacterManager.Instance.Player.controller.moveSpeed /= speed;
    }
}
