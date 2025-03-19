using UnityEngine;


public class Movement3D :MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;     // 이동속도

    private Vector3 moveDirection;      // 이동방향
    private float gravity = -9.81f;     // 중력 계수
    private float jumpForce = 3.0f;     // 뛰는힘

    [SerializeField]
    private Transform cameraTransform;

    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        // cameraTransform을 메인 카메라의 Transform으로 설정
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    private void Update()
    {
        if (characterController.isGrounded == false)    // 공중에 떠있을때 
        {
            moveDirection.y += gravity * Time.deltaTime;    // y축 이동방향 게속 감소 
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
        if(characterController.isGrounded == true)      // 캐릭터가 땅에 닿아있으면 
        {
            moveDirection.y = jumpForce;        // 점프힘 3
        }
    }
}
