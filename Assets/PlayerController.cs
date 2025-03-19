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
        // InputSystem�� ����Ͽ� ����Ű �Է� �ޱ�
        float x = 0;
        float z = 0;

        if (Keyboard.current.aKey.isPressed) x = -1; // ����
        if (Keyboard.current.dKey.isPressed) x = 1;  // ������
        if (Keyboard.current.wKey.isPressed) z = 1;  // ��
        if (Keyboard.current.sKey.isPressed) z = -1; // �Ʒ�
        movement3D.MoveTo(new Vector3(x, 0, z));

        // ���� �Է� ó�� (Input System ���)
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            movement3D.JumpTo();
        }

        // ī�޶� �̵� ó��
        if (cameraController != null)
        {
            float mouseX = Mouse.current.delta.x.ReadValue(); // ���콺 ��/�� ������
            float mouseY = Mouse.current.delta.y.ReadValue(); // ���콺 ��/�Ʒ� ������
            cameraController.RotateTo(mouseX, mouseY);
        }

    }
}
