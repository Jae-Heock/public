using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Movement3D movement3D;
    private KeyCode jumpKeyCode = KeyCode.Space;
    [SerializeField]
    private CameraController cameraController;

    private void Awake()
    {
        movement3D = GetComponent<Movement3D>();
    }

    private void Update()
    {
        // InputSystem을 사용하여 방향키 입력 받기
        float x = 0;
        float z = 0;

        if (Keyboard.current.aKey.isPressed) x = -1; // 왼쪽
        if (Keyboard.current.dKey.isPressed) x = 1;  // 오른쪽
        if (Keyboard.current.wKey.isPressed) z = 1;  // 위
        if (Keyboard.current.sKey.isPressed) z = -1; // 아래
        movement3D.MoveTo(new Vector3(x, 0, z));

        // 점프 입력 처리 (Input System 사용)
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            movement3D.JumpTo();
        }

        // 카메라 이동 처리
        if (cameraController != null)
        {
            float mouseX = Mouse.current.delta.x.ReadValue(); // 마우스 좌/우 움직임
            float mouseY = Mouse.current.delta.y.ReadValue(); // 마우스 위/아래 움직임
            cameraController.RotateTo(mouseX, mouseY);
        }

    }
}
