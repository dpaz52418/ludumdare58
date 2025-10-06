using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float defaultMoveSpeed = 6f;
    [SerializeField] private Animator _animator;
    private Rigidbody2D rb;
    private Vector2 moveInput;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput.normalized * moveSpeed;
        _animator.SetFloat("Speed", moveSpeed);
   }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }


    // Called by other scripts
    public void setSpeed(int nuts)
    {
        if (nuts == 5)
        {
            float rat = 0.4f;
            moveSpeed = (defaultMoveSpeed * rat);
        }
        else if (nuts == 3)
        {
            float rat = 0.6f;
            moveSpeed = (defaultMoveSpeed * rat);
        }
        else if (nuts == 2)
        {
            float rat = 0.8f;
            moveSpeed = (defaultMoveSpeed * rat);
        }
        else if (nuts == 1)
        {
            float rat = 0.9f;
            moveSpeed = (defaultMoveSpeed * rat);
        }
        else
        {
            moveSpeed = defaultMoveSpeed;
        }
    }
}
