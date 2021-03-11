using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 이동 속도 
    public float moveSpeed = 7f;
    // 중력 변수
    float gravity = -20f;
    // 수직 속력 변수
    float yVelocity = 0;
    // 점프력 변수
    public float jumpPower = 10f;
    // 점프 상태 변수
    public bool isJumping = false;
    // 체력 변수
    public int hp = 10;

    // 캐릭터 콘트롤러 변수
    CharacterController cc;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        // W, A, S, D 키를 입력하면 캐릭터를 그 뱡향으로 이동시키고 싶다.

        // 1. 사용자의 입력을 받는다.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 2. 이동 방향을 설정한다.
        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        // 2-1. 메인 카메라를 기준으로 방향을 변환한다.
        dir = transform.TransformDirection(dir);

      
        // 2-2. 만일. 다시 바닥에 착지했다면...
        if (cc.collisionFlags == CollisionFlags.Below)
        {
            // 만일 점프 중이었다면...
            if (isJumping)
            {
                // 점프 전 상태로 초기화한다.
                isJumping = false;
            }
                //캐릭터 수직 속도를 0으로 만든다.
                yVelocity = 0;
        }

        // 2-3. 만일, 키보드 [Spacebar]키를 입력했고, 점프를 하지 않은 상태라면...
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            // 캐릭터 수직 속도에 점프력을 적용하고 점프 상태로 변경한다.
            yVelocity = jumpPower;
            isJumping = true;
        }
        // 2-2. 캐릭터 수직 속도에 중력 값을 적용한다.
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        // 3. 이동 속도에 맞춰 이동한다.
        cc.Move(dir * moveSpeed * Time.deltaTime);
    }

    // 플레이어 피격 함수
    public void OnDamage(int value)
    {
        hp -= value;
        if(hp<0)
        {
            hp = 0;
        }
    }
}
