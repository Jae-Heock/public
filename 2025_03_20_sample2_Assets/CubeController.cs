using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeController : MonoBehaviour
{
    // GameManager GameManager;
    public AudioClip collisionSound;  // 충돌 시 재생할 소리
    AudioSource aud;  // 오디오 소스를 저장할 변수

    [SerializeField]
    private Vector3 mRotateSpeed;

    private void Start()
    {
        this.aud = GetComponent<AudioSource>();  // 오디오 소스 추가
        this.aud.clip = collisionSound;  // 소리 지정
    }

    public void OnTriggerEnter(Collider other)
    {
        aud.PlayOneShot(collisionSound);
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            Debug.Log("ENTER : 충돌감지");
            GameObject controllerObj = GameObject.FindGameObjectWithTag("GameController");
            GameManager controller = controllerObj.GetComponent<GameManager>();
            controller.AddScore(1);
            
        }
    }

    private void Update()
    {
        transform.Rotate(mRotateSpeed * Time.deltaTime); // 아이템화(빙글빙글)
    }
}
