using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;

    float span = 1.0f;      // �������� �����Ǵ� �ð� -> 1��
    float delta = 0;        // �ð� ���� ���� 
    // ex) 1�ʰ� ������ delta�� 1�� ��. ��, 1�ʸ��� span ���� Ŀ���ϱ� 1�ʸ��� �������� �����ϴ°�.

    int ratio = 2;
    float speed = -0.03f;

    public void SetParameter(float span, float speed, int ratio)
    {
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;
    }

    public void Update()
    {
        this.delta += Time.deltaTime;

        if (this.delta > this.span)     // delta�� span���� ũ�� ��� ���� 
        {
            this.delta = 0;
            GameObject item;

            int dice = Random.Range(1, 11);
            if(dice <= this.ratio)
            {
                item = Instantiate(bombPrefab);
            }
            else
            {
                item = Instantiate(applePrefab);
            }

            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);
            item.GetComponent<ItemController>().dropSpeed = this.speed;
        }
    }
}
