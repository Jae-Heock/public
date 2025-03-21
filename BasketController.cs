using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource aud;
    GameObject director;

    // Start() 메서드는 게임이 시작될 때 한 번 실행됨.
    void Start()
    {
        // 게임의 프레임 속도를 60FPS로 고정
        Application.targetFrameRate = 60;
        this.aud = GetComponent<AudioSource>();
        this.director = GameObject.Find("GameDirector");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Apple")
        {
            Debug.Log("Tag=Apple");
            this.aud.PlayOneShot(this.appleSE);
            this.director.GetComponent<GameDirector>().GetApple();
        }
        else 
        {
            Debug.Log("Tag=Bomb");
            this.aud.PlayOneShot(this.bombSE);
            this.director.GetComponent<GameDirector>().GetBomb();
        }
        Destroy(other.gameObject);
    }


    // Update() 메서드는 매 프레임마다 실행됨
    public void Update()
    {
        // 마우스 왼쪽 버튼을 눌렀을 때 실행
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스 클릭 위치에서 카메라가 쏘는 광선(ray)을 생성
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; // Ray가 부딪힌 지점을 저장할 변수

            // 광선(ray)이 충돌한 오브젝트가 있을 경우 실행
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // 충돌한 지점의 x, z 좌표를 정수로 반올림하여 가져옴
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);

                // 바구니(Basket)의 위치를 클릭한 지점으로 이동 (y 좌표는 0으로 고정)
                transform.position = new Vector3(x, 0, z);
            }
        }
    }
}
