using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movement2D Movement2D;
    private Skilment2D Skilment2D;
    private Rigidbody2D Rigidbody2D;

    //루비가 가만히 있을시 바라보는 방향 지정
    //지정해 주지 않으면 상태머신은 어느 방향을 취해야 할지 모른다
    Vector2 lookDirection = new Vector2(1, 0);


    void Awake()
    {
        Movement2D = GetComponent<Movement2D>();
        Skilment2D = GetComponent<Skilment2D>();
        Rigidbody2D= GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        //좌우 이동 방향 제어
        Movement2D.Move3();

        //플레이어 점프
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Movement2D.Jump();
        }
        //플레이어 앉기
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Movement2D.SitDown(false);
        }
        //플레이어 일어나기
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Movement2D.SitDown(true);
        }
        //스킬 전환
        else if (Input.GetKeyDown(KeyCode.F))
        {
            Skilment2D.selectedSlot += 1;

            if (Skilment2D.selectedSlot >= 3)
            {
                Skilment2D.selectedSlot =0;
            }
        }
        //스킬 시전
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Skilment2D.selectedSlot == 0)
            {
                Skilment2D.FirstSkill();
            }
            else if (Skilment2D.selectedSlot == 1)
            {
                Skilment2D.SecondSkill();
            }
            else if (Skilment2D.selectedSlot == 2)
            {
                Skilment2D.ThirdSkill();
            }
        }

        //레이캐스트(NPC와 대화하기)
        if (Input.GetKeyDown(KeyCode.D))
        {
            //레이는 시작 포인트, 방향 및 길이로 구성됩니다
            //루비의 발이 아닌 루비 중앙에서 수행, 루비가 바라보는 방향, 최대거리, 특정레이어만 실행을 위해 마스크에 속하지 않을시 무시
            //레이캐스트가 콜라이더와 닿는지 확인
            RaycastHit2D hit = Physics2D.Raycast(Rigidbody2D.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));

            if (hit.collider != null)
            {
                //충돌이 있는지 확인한 다음 레이캐스트가 충돌한 오브젝트에서 NonPlayerCharacter 스크립트를 찾습니다.
                //이 오브젝트에 해당 스크립트가 있는 경우 대화상자를 표시합니다.
                //Debug.Log("Raycast has hit the object " + hit.collider.gameObject);
                Debug.Log("D키를 눌러 대화를 시도합니다" );

                ObjInteraction objInteraction = hit.collider.GetComponent<ObjInteraction>();
                if (objInteraction != null)
                {
                    objInteraction.DisplayDialog();
                }
            }
        }

    }
}
