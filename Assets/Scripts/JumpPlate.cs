using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlate : MonoBehaviour
{
    public float jumpAcceletor;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IJumpBoost>(out IJumpBoost jumpBoost))
        {
            Debug.Log("���� �ν�Ʈ");
            jumpBoost.JumpBoost(jumpAcceletor);
        }
    }
}
