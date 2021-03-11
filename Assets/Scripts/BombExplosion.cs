using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public GameObject explosion;

    // 만일, 충돌한다면 자신을 제거
    private void OnCollisionEnter(Collision collision)
    {
        GameObject go =Instantiate(explosion);
        go.transform.position = collision.GetContact(0).point;

        Destroy(gameObject);
    }
}
