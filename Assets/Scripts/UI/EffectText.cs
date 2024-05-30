using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EffectText : MonoBehaviour
{
    TextMeshProUGUI textMeshPro;

    List<string> effectString = new List<string>();

    private void Awake()
    {
        CharacterManager.Instance.EffectText = this;

        textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.text = string.Empty;
    }

    public void AddonText(string txt, int time = 1)
    {
        textMeshPro.text = txt;
        StartCoroutine(RemoveText(time));
    }

    IEnumerator RemoveText(int time)
    {
        yield return new WaitForSeconds(time);
        textMeshPro.text = string.Empty;
    }
}
