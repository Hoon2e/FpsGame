﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    // 목표가 될 트랜스폼 컴포넌트
    public Transform target;
    void Update()
    {
        transform.position = target.position;
    }
}
