using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    public float Length = 5;
    LineRenderer lineRenderer;

    Transform targetPos;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        targetPos = transform;
        //targetPos.localPosition += transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, targetPos.localPosition + transform.up * Length);
    }
}
