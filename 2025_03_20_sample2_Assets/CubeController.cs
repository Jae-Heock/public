using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeController : MonoBehaviour
{
    // GameManager GameManager;
    public AudioClip collisionSound;  // �浹 �� ����� �Ҹ�
    AudioSource aud;  // ����� �ҽ��� ������ ����

    [SerializeField]
    private Vector3 mRotateSpeed;

    private void Start()
    {
        this.aud = GetComponent<AudioSource>();  // ����� �ҽ� �߰�
        this.aud.clip = collisionSound;  // �Ҹ� ����
    }

    public void OnTriggerEnter(Collider other)
    {
        aud.PlayOneShot(collisionSound);
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            Debug.Log("ENTER : �浹����");
            GameObject controllerObj = GameObject.FindGameObjectWithTag("GameController");
            GameManager controller = controllerObj.GetComponent<GameManager>();
            controller.AddScore(1);
            
        }
    }

    private void Update()
    {
        transform.Rotate(mRotateSpeed * Time.deltaTime); // ������ȭ(���ۺ���)
    }
}
