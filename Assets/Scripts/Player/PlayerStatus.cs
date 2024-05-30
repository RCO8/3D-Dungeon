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
                //체력 회복
                CharacterManager.Instance.EffectText.AddonText(item.itemData.EffectText);   //효과를 텍스트에
                hp.Add(item.itemData.Recover);
                break;
            case PotionItem.Skill:
                //스킬 회복
                CharacterManager.Instance.EffectText.AddonText(item.itemData.EffectText);
                sp.Add(item.itemData.Recover);
                break;
            case PotionItem.SpeedUp:
                //일정 시간동안 스피드 업
                if(item.gameObject.TryGetComponent<SpeedPotion>(out SpeedPotion speed))
                {
                    //얻었으면 효과와 동시에 텍스트 띄우기
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
