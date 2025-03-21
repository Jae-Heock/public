using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;

    float span = 1.0f;      // 아이템이 생성되는 시간 -> 1초
    float delta = 0;        // 시간 누적 변수 
    // ex) 1초가 지나면 delta는 1이 됨. 즉, 1초마다 span 보다 커지니까 1초마다 아이템을 생성하는것.

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

        if (this.delta > this.span)     // delta가 span보다 크면 사과 생성 
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
