using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Skilment2D : MonoBehaviour
{
    //스킬을 담을 공간
    //public int[] SkillSlot = new int[3];  //스킬 슬롯 3개
    public int selectedSlot;  // 선택된 퀵슬롯의 인덱스 (0~2)
    //각 스킬에 따른 쿨타임
    float skillOne = 10.0f;
    float skillTwo = 10.1f;
    float skillThree = 10.1f;

    //스킬이 쿨타임인지 판별
    bool skillOneCooldown = true;
    bool skillTwoCooldown = true;
    bool skillThreeCooldown = true;

    float onw1;
    float onw2;
    float onw3;

    

    // Start is called before the first frame update
    void Start()
    {
        selectedSlot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //첫 번째 스킬 쿨타임
        if (skillOneCooldown == false)
        {
            onw1 -= Time.deltaTime;
            if (onw1 < 0)
            {
                skillOneCooldown = true;
            }
        }
        //두 번째 스킬 쿨타임
        if (skillTwoCooldown == false)
        {
            onw2 -= Time.deltaTime;
            if (onw2 < 0)
            {
                skillTwoCooldown = true;
            }
        }

        //세 번째 스킬 쿨타임
        if (skillThreeCooldown == false)
        {
            onw3 -= Time.deltaTime;
            if (onw3 < 0)
            {
                skillThreeCooldown = true;
            }
        }
    }

    //첫번째 스킬
    public void FirstSkill()
    {
        if (skillOneCooldown)
        {
            Debug.Log("첫번째스킬을 발동하였습니다");
            skillOneCooldown = false;
            onw1 = skillOne;
        }
        else
        {
            Debug.Log("첫번째 스킬은 쿨타임 입니다");
        }
        
    }
    //두번째 스킬
    public void SecondSkill()
    {
        if (skillTwoCooldown)
        {
            Debug.Log("두번째스킬을 발동하였습니다");
            skillTwoCooldown = false;
            onw2 = skillTwo;
        }
        else
        {
            Debug.Log("두번째 스킬은 쿨타임 입니다");
        }
    }
    //세번째 스킬
    public void ThirdSkill()
    {
        if (skillThreeCooldown)
        {
            Debug.Log("세번째스킬을 발동하였습니다");
            skillThreeCooldown = false;
            onw3 = skillThree;
        }
        else
        {
            Debug.Log("세번째 스킬은 쿨타임 입니다");
        }
    }
}
