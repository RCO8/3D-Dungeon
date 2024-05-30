using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    public float Length = 5;
    public LayerMask PlayerHit;
    LineRenderer lineRenderer;

    Transform targetPos;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        targetPos = transform;
        //targetPos.localPosition += transform.up;
    }

    void Update()
    {
        //라인 그리기
        DrawLine();

        //레이저 맞추기
        AimObject();
    }

    void DrawLine()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, targetPos.localPosition + transform.up * Length);
    }

    void AimObject()
    {
        Ray ray = new Ray(transform.position, transform.up * Length);
        RaycastHit hit;

        //Debug.DrawRay(transform.position, transform.up * Length, Color.blue);

        if (Physics.Raycast(ray, out hit, Length, PlayerHit))
        {
            //Debug.Log("플레이어 감지");
            if (hit.collider.TryGetComponent<Player>(out Player player))
            {
                player.status.DecreaseHP(3);
            }
        }

    }
}
