using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Point")]
    public Vector3 startPos;
    public Vector3 endPos;

    [Header("Movement")]
    public float waitTime;  //대기시간
    public float speed;     //이동속도

    float time = 0;

    Rigidbody rgdBody;

    // Start is called before the first frame update
    void Start()
    {
        rgdBody = GetComponent<Rigidbody>();
        transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (startPos.x != endPos.x)
            MovePlatform(transform.position.x, startPos.x, endPos.x);
        if (startPos.y != endPos.y)
            MovePlatform(transform.position.y, startPos.y, endPos.y);
        if (startPos.z != endPos.z)
            MovePlatform(transform.position.z, startPos.z, endPos.z);
    }

    void MovePlatform(float nowTransfom, float startTransform, float endTransform)
    {

        if (startTransform < endTransform)
        {
            //endPos까지 닿으면 대기시간 후 다시 반대로
            if (nowTransfom >= endTransform)
            {
                transform.Translate(Vector3.zero);

                time += Time.deltaTime;
                if (time >= waitTime)
                {
                    time = 0;
                    ChangePosition();
                }
            }
            else
            {
                transform.Translate((endPos - startPos).normalized * Time.deltaTime * speed);
            }
        }
        if (startTransform > endTransform)
        {
            if (nowTransfom <= endTransform)
            {
                transform.Translate(Vector3.zero);

                time += Time.deltaTime;
                if (time >= waitTime)
                {
                    time = 0;
                    ChangePosition();
                }
            }
            else
            {
                transform.Translate((startPos - endPos).normalized * Time.deltaTime * -speed);
            }
        }
    }

    void ChangePosition()
    {
        //Debug.Log("Change");
        Vector3 tmp = startPos;
        startPos = endPos;
        endPos = tmp;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.transform.SetParent(null);
        }
    }
}
