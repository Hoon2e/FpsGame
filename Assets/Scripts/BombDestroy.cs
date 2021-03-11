using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDestroy : MonoBehaviour
{
    float destroyTime = 1.5f;

    // 경과된 시간 변수
    float currentTime = 0;

    void Start()
    {
        
    }

    void Update()
    {
        // 생성된 때로부터 2초가 경과되면 사라진다.
        if(currentTime >= destroyTime)
        {
            Destroy(gameObject);
        }
        currentTime += Time.deltaTime;
    }
}
