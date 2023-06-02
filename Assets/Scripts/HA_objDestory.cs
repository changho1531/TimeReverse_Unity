using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HA_objDestory : MonoBehaviour
{
    public GameObject rock;
    public Sprite newSprite;
    public SpriteRenderer spriteRenderer;

    public bool start;
    public bool destroy;
    public bool boolFlower;

    public GameObject flower_1;
    public GameObject flower_2;
    public GameObject flower_3;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        flower_2.SetActive(false);
        flower_3.SetActive(false);
    }

    public void Update()
    {
        if (start)
        {
            spriteRenderer.sprite = newSprite;
            Invoke("delay_1", 1f);
        }

        if (destroy)
        {
            Color color = spriteRenderer.color;
            Invoke("delay_2", 1.5f);
        }

        if(boolFlower)
        {
            flower_2.SetActive(true);
            flower_3.SetActive(true);
        }
    }

    public void delay_1()
    {
        destroy = true;
    }

    public void delay_2()
    {
        Destroy(rock);
    }
}
