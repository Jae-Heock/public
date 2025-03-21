using UnityEngine;
using UnityEngine.InputSystem;

public class Playercontroller : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerInputAction playerInput;
    private Vector2 movementVector;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = new PlayerInputAction();  // 🔹 생성된 InputAction 사용
    }

    private void OnEnable()
    {
        playerInput.Enable();
        playerInput.Player.Move.performed += ctx => movementVector = ctx.ReadValue<Vector2>();
        playerInput.Player.Move.canceled += ctx => movementVector = Vector2.zero;
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(movementVector.x, 0, movementVector.y);
        rb.AddForce(move * 10f);
    }
}
