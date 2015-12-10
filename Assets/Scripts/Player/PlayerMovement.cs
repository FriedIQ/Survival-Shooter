using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 6f;

    Vector3 _movement;
    Animator _animator;
    Rigidbody _ridgidbody;
    int _floorMask;
    private const float _camRayLength = 100f;

    void Awake()
    {
        _floorMask = LayerMask.GetMask("Floor");
        _animator = GetComponent<Animator>();
        _ridgidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turn();
        Animating(h, v);
    }

    void Move(float h, float v)
    {
        _movement.Set(h, 0f, v);
        _movement = _movement.normalized * Speed * Time.deltaTime;

        _ridgidbody.MovePosition(transform.position + _movement);
    }

    void Turn()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;
        if(Physics.Raycast(camRay, out floorHit, _camRayLength, _floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion rotation = Quaternion.LookRotation(playerToMouse);
            _ridgidbody.MoveRotation(rotation);
        }
    }

    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;

        _animator.SetBool("IsWalking", walking);
    }
}
