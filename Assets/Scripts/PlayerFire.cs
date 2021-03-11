using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerFire : MonoBehaviour
{
    // 발사 위치
    public GameObject firePosition;
    // 투척 무기 오브젝트
    public GameObject bombFacory;
    // 투척 파워
    public float throwPower = 15f;

    // 피격 이펙트 오브젝트
    public GameObject bulletEffect;
    // 피격 이펙트 파티클 시스템
    ParticleSystem ps;

   // 마우스 좌 클릭을 하면, 시선 방향에 총을 발사한다.
   // 부딪힌 대상의 이름을 출력한다.

    void Start()
    {
        // 피격 이펙트 오브젝트에서 파티클 시스템 컴포넌트 가져오기
        ps = bulletEffect.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        // 만일 마우스 좌 클릭을 한다면...
        if(Input.GetMouseButtonDown(0))
        {
                // 피격 사운드 발생
                bulletEffect.GetComponent<AudioSource>().Play();
            // 1. 레이를 생성
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            // 2. 레이에 부딪힌 대상이 정보를 저장할 변수
            RaycastHit hitInfo = new RaycastHit();
            
            if(Physics.Raycast(ray, out hitInfo))
            {
                // 피격 이펙트의 위치를 레이가 부딪힌 지점으로 이동시킨다.
                bulletEffect.transform.position = hitInfo.point;
                 
                // 피격 이펙트의 forward 방향을 레이가 부딪힌 지점의 법선 벡터와 일치시킨다.
                bulletEffect.transform.forward = hitInfo.normal;
                // 피격 이펙트를 플레이한다.
                ps.Play();
            }
        }


     if(Input.GetMouseButtonDown(1))
        {
            GameObject bomb = Instantiate(bombFacory);
            bomb.transform.position = firePosition.transform.position;

            Rigidbody rb = bomb.GetComponent<Rigidbody>();

            rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
        }
    }
}
