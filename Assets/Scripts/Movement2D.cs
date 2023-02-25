using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    public float speed = 5.0f; // 걷기속도
    float defaultSpeed;
    Rigidbody2D Rigidbody2D;
    public float jumpForce = 8.0f; // 점프 힘

    //바닥 판정, 점프제어
    public LayerMask groundLayer;               // 바닥 체크를 위한 충돌 레이어
    public LayerMask obj;                       // 오브젝트 발판 충돌 레이어

    public CapsuleCollider2D CapsuleCollider2D;        // 캡슐 오브젝트의 충돌 범위 컴포넌트
    bool isGrounded;                            // 바닥체크 (바닥에 닿아있을때 true)
    public Collider2D isObj;                    // 바닥체크 ()

    Vector3 footPosition;               //발의 위치

    Animator animator;                    //애니메이션
    Vector2 lookDirection = new Vector2(1, 0);    //캐릭터 기본 바라보는 방향

    bool sit_ing = false;             //캐릭터 기본상태
    void Awake()
    {
        defaultSpeed = speed;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        CapsuleCollider2D = GetComponent<CapsuleCollider2D>();
        animator = gameObject.GetComponentInChildren<Animator>();

    }

    private void FixedUpdate()
    {
        //플레이어 오브젝트의 충돌범위 BoxCollider2D min, center, max 위치 정보
        Bounds bounds = CapsuleCollider2D.bounds;

        //플레이어의 발 위치 설정
        footPosition = new Vector2(bounds.center.x, bounds.min.y);

        //플레이어의 발 위치에 원을 생성하고, 원이 바닥과 닿아있으면 isGrounded = true
        //포지션위치에 반지름 크기의 보이지 않는 원 충돌 범위를 생성
        //원에 충돌하는 오브젝트의 Collider2D 컴포넌트를 저장
        isGrounded = Physics2D.OverlapCircle(footPosition, 0.1f, groundLayer);
        isObj = Physics2D.OverlapCircle(footPosition, 0.1f, obj);
    }

    //좌우 이동함수
    public void Move()
    {
        //left or a =-1 / right or d =1
        float x = Input.GetAxisRaw("Horizontal");
        //x축 이동은 x* speed로, y축 이동은 기존의 속력 값(현재는 중력)
        Rigidbody2D.velocity = new Vector2(x * defaultSpeed, Rigidbody2D.velocity.y);

    }
    public void Move2()
    {
        //left or a =-1 / right or d =1
        float x = Input.GetAxisRaw("Horizontal");
        //x축 이동은 x* speed로, y축 이동은 기존의 속력 값(현재는 중력)

        Rigidbody2D.velocity = new Vector2(x * defaultSpeed, Rigidbody2D.velocity.y);

        //if (!Mathf.Approximately(Rigidbody2D.velocity.x, 0.0f) || !Mathf.Approximately(Rigidbody2D.velocity.y, 0.0f))
        //{
            lookDirection.Set(Rigidbody2D.velocity.x, Rigidbody2D.velocity.y);
            lookDirection.Normalize();
        //}
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", lookDirection.magnitude);

    }

    //점프 함수
    public void Jump()
    {
        if(isGrounded == true || isObj==true)
        {
            //jumpForce의 크기만큼 윗쪽 방향으로 속력 설정
            Rigidbody2D.velocity = Vector2.up * jumpForce;

        }
    }

    //앉기
    public void SitDown(bool sit_ing)
    {
        if(isGrounded == true && sit_ing == false)
        {
            //속력조절 앉을 때
            defaultSpeed = 1.0f;
            //박스범위 조절
            CapsuleCollider2D.size = new Vector2((float)0.23, (float)0.59);
            CapsuleCollider2D.offset = new Vector2(0, (float)-0.18);
        }
        else if(isGrounded == true && sit_ing == true)
        {
            //기본 상태
            defaultSpeed = speed;
            CapsuleCollider2D.size = new Vector2((float)0.23, (float)0.93);
            CapsuleCollider2D.offset = new Vector2(0, (float)-0.015);
        }
    }
}
