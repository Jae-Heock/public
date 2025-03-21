using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource aud;
    GameObject director;

    // Start() �޼���� ������ ���۵� �� �� �� �����.
    void Start()
    {
        // ������ ������ �ӵ��� 60FPS�� ����
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


    // Update() �޼���� �� �����Ӹ��� �����
    public void Update()
    {
        // ���콺 ���� ��ư�� ������ �� ����
        if (Input.GetMouseButtonDown(0))
        {
            // ���콺 Ŭ�� ��ġ���� ī�޶� ��� ����(ray)�� ����
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; // Ray�� �ε��� ������ ������ ����

            // ����(ray)�� �浹�� ������Ʈ�� ���� ��� ����
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // �浹�� ������ x, z ��ǥ�� ������ �ݿø��Ͽ� ������
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);

                // �ٱ���(Basket)�� ��ġ�� Ŭ���� �������� �̵� (y ��ǥ�� 0���� ����)
                transform.position = new Vector3(x, 0, z);
            }
        }
    }
}
