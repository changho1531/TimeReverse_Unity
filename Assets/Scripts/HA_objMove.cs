using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HA_objMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 targetPosition;
    public Vector2 originPosition;
    public bool targetPoint;
    public bool originPoint;

    public void Start()
    {
        targetPoint = false;
        originPoint = false;
    }

    void Update()
    {
        if (targetPoint)
        {
            // 현재 위치와 목표 위치 사이의 거리 계산
            float distance = Vector2.Distance(transform.position, targetPosition);

            // 목표 위치에 도달하면 이동 중지
            if (distance <= 0.01f)
            {
                targetPoint = false;
            }
            else
            {
                // 목표 위치로 향하는 방향 계산
                Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
                // 목표 위치까지의 거리에 비례하여 이동 속도 계산
                float speed = Mathf.Clamp01(distance / moveSpeed) * moveSpeed;
                // 이동
                transform.Translate(direction * speed * Time.deltaTime);
            }
        }

        if (originPoint)
        {
            float distance = Vector2.Distance(transform.position, originPosition);

            if (distance <= 0.01f)
            {
                originPoint = false;
                Debug.Log(originPoint);
            }
            else
            {
                Vector2 direction = (originPosition - (Vector2)transform.position).normalized;
                float speed = Mathf.Clamp01(distance / moveSpeed) * moveSpeed;
                transform.Translate(direction * speed * Time.deltaTime);
            }
        }
    }
}