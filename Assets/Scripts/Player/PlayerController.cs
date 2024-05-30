using UnityEngine;
using UnityEngine.InputSystem;

interface IJumpBoost
{
    public void JumpBoost(float boost);
}

public class PlayerController : MonoBehaviour, IJumpBoost
{
    Rigidbody rgdby;

    [Header("Movement")]
    public float moveSpeed;
    public float jumpPower;
    int curJump;
    const int canJump = 2;
    Vector2 movement;
    public LayerMask groundMaskLayer;

    [Header("LookTarget")]
    public Transform cam;
    public float minXRot = -85f;
    public float maxXRot = 85f;
    public float lookSensetive;
    private float camRotX;
    Vector2 lookTarget;

    private bool isAction;  //마우스 클릭

    private void Awake()
    {
        rgdby = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        curJump = canJump;
    }

    private void FixedUpdate()
    {
        Moving();
    }

    private void LateUpdate()
    {
        Looking();
        ObjectTarget();
    }

    private void Moving()
    {
        Vector3 dir = transform.forward * movement.y + transform.right * movement.x;
        dir *= moveSpeed;
        dir.y = rgdby.velocity.y;

        rgdby.velocity = dir;
    }
    private void Looking()
    {
        camRotX += lookTarget.y * lookSensetive;
        camRotX = Mathf.Clamp(camRotX, minXRot, maxXRot);
        cam.localEulerAngles = new Vector3(-camRotX, 0, 0);

        transform.eulerAngles += new Vector3(0, lookTarget.x * lookSensetive, 0);
    }
    private void ObjectTarget() //플레이어 앞에 오브젝트가 있으면
    {
        Ray frontObject = new Ray(cam.position, Vector3.forward);
        if (Physics.Raycast(cam.position, Vector3.forward, 1.5f) && isAction)
        {
            //음... 일단 닿으면 옵션 UI표시하고 클릭하면 액션
            //아이템을 확인하다.
            Debug.Log("오브젝트 확인");
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
            movement = context.ReadValue<Vector2>();
        else if(context.phase == InputActionPhase.Canceled)
            movement = Vector2.zero;
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        lookTarget = context.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGround())
        {
            rgdby.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
        }
    }
    public void OnAction(InputAction.CallbackContext context)
    {
        isAction = context.phase == InputActionPhase.Performed;
    }

    bool IsGround()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + ( transform.forward * .05f) + (transform.up * .01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * .05f) + (transform.up * .01f), Vector3.down),
            new Ray(transform.position + ( transform.right   * .05f) + (transform.up * .01f), Vector3.down),
            new Ray(transform.position + (-transform.right   * .05f) + (transform.up * .01f), Vector3.down)
        };

        for(int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], groundMaskLayer))
            {
                return true;
            }
        }
        return false;
    }

    public void JumpBoost(float boost)
    {
        //점프 가속
        rgdby.AddForce(Vector3.up * boost, ForceMode.Impulse);
    }
}
