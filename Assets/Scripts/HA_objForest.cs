using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HA_objForest : MonoBehaviour
{
    public bool isUse;

    public float shrinkSpeed = 1f; // 크기가 작아지는 속도를 조절하기 위한 변수

    private Vector3 initialScale; // 초기 크기 저장을 위한 변수

    private void Start()
    {
        initialScale = transform.localScale; // 초기 크기 저장
    }

    private void Update()
    {
        if(isUse)
        {
            // 크기를 작게 만들기
            transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;

            // 크기가 일정 수준 이하로 작아지면 오브젝트를 삭제
            if (transform.localScale.x <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
