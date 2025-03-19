using UnityEngine;


public class Movement3D :MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;     // �̵��ӵ�

    private Vector3 moveDirection;      // �̵�����
    private float gravity = -9.81f;     // �߷� ���
    private float jumpForce = 3.0f;     // �ٴ���

    [SerializeField]
    private Transform cameraTransform;

    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        // cameraTransform�� ���� ī�޶��� Transform���� ����
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    private void Update()
    {
        if (characterController.isGrounded == false)    // ���߿� �������� 
        {
            moveDirection.y += gravity * Time.deltaTime;    // y�� �̵����� �Լ� ���� 
        }
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        // moveDirection = direction;
        Vector3 movedis = cameraTransform.rotation * direction;
        moveDirection = new Vector3(movedis.x, moveDirection.y, movedis.z);
    }

    public void JumpTo()
    {
        if(characterController.isGrounded == true)      // ĳ���Ͱ� ���� ��������� 
        {
            moveDirection.y = jumpForce;        // ������ 3
        }
    }
}
