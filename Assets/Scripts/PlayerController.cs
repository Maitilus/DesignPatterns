using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float dashPower;
    [SerializeField] private InputActionReference iar_MovementControls;
    [SerializeField] private InputActionReference iar_DashControls;
    private Rigidbody2D rb;
    public Vector2 v2_MoveInput;
    Dasher dasher;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        ICommand DashCommand = new DashCommand(this);
        dasher = new Dasher(DashCommand);
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

    void OnDashPerformed(InputAction.CallbackContext context)
    {
        dasher.DoDash();
    }
    public void PerformDashPhysics()
    {
        rb.AddForce(v2_MoveInput.normalized * dashPower, ForceMode2D.Impulse);
    }

    //Observer
    void OnEnable()
    {
        iar_DashControls.action.performed += OnDashPerformed;
    }

    void OnDisable()
    {
        iar_DashControls.action.performed -= OnDashPerformed;
    }
}
