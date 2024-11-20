
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
/////////////// INFORMATION ///////////////
// This script automatically adds a Rigidbody2D and a CapsuleCollider2D component in the inspector.
// The following components are needed: Player Input
    [RequireComponent(typeof(Rigidbody2D),typeof(CapsuleCollider2D))]
public class TopDownMovement : MonoBehaviour
{
    public float maxSpeed = 7;
    public bool controlEnabled { get; set; } = true; // You can edit this variable from Unity Events
    public UnityEvent onAction1, onAction2;
    private Vector2 _moveInput;
    private Rigidbody2D _rb;
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
// Set gravity scale to 0 so player won't "fall"
        _rb.gravityScale = 0;
    }

    private void FixedUpdate()
    {
// Set velocity based on direction of input and maxSpeed
        if (controlEnabled)
        {
            _rb.velocity = _moveInput.normalized*maxSpeed;
        }
        else
        {
            _rb.velocity = Vector2.zero;
        }
// Write code for walking animation here. (Suggestion: send your current velocity into the Animator for both the x- and y-axis.)
    }
// Handle Move-input
// This method can be triggered through the UnityEvent in PlayerInput
    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>().normalized;
    }
    public void Action1(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            onAction1.Invoke();
            Debug.Log("Diddykong");
        }
    }
    public void Action2(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            onAction2.Invoke();
        }
    }
}