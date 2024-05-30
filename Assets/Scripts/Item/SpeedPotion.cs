using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPotion : MonoBehaviour
{
    ItemObject item;

    public float AddSpeed;
    public int duringTime;
    private float upgradeSpeed;


    void Start()
    {
        item = GetComponent<ItemObject>();
        upgradeSpeed = CharacterManager.Instance.Player.controller.moveSpeed;
    }

    public void GetSpeed()
    {
        Debug.Log("스피드업 효과");
    }
}
