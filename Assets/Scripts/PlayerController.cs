using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] private InputActionReference iar_MovementControls;
    private Rigidbody2D rb;
    private Vector2 v2_MoveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetInput();
    }

    void FixedUpdate()
    {
        Movement(v2_MoveInput);
    }

    void GetInput()
    {
        v2_MoveInput = iar_MovementControls.action.ReadValue<Vector2>();
    }
    
    void Movement(Vector2 moveInput)
    {
        rb.AddForce(moveInput.normalized * moveSpeed);
    }
}
