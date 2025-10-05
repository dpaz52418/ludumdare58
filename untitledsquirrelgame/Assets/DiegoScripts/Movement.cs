using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float moveSpeed = 12;
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
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void setSpeed(int nuts)
    {
        if (nuts == 5)
        {
            //moveSpeed = 
        }
    }
}
