using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HA_fadeEffect : MonoBehaviour  
    //고박사의 유니티 노트(유튜브) [Unity Basic Skills] 05. 페이드 효과 (Fade Effect)
{
    private Image image;    //페이드 효과에 사용하는 검은 바탕 이미지

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        //image의 color 프로퍼티는 a변수만 따로 set이 불가능해서 변수에 저장
        Color color = image.color;

        //알파 값(a)이 0보다 크면 알파값 감소
        if (color.a > 0)
        {
            color.a -= Time.deltaTime;
        }

        //바뀐 색상 정보를 image.color에 저장
        image.color = color;
    }
}
