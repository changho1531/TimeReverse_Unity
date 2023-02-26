using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test111 : MonoBehaviour
{

    Movement2D Movement2D;
    float skillOne = 5.0f;
    bool skillOneCooldown = true;
    float onw1;
    // Start is called before the first frame update
    void Start()
    {
        Movement2D = GetComponent<Movement2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FirstSkill()
    {
        if (skillOneCooldown && Movement2D.isObj)
        {
            Debug.Log("첫번째 스킬을 사용했습니다");

            Movement2D.isObj.transform.localScale = new Vector2((float)5.4, (float)5.4);

            float xxxx =Movement2D.isObj.transform.localScale.x;
            float yyyy = Movement2D.isObj.transform.localScale.y;

            Vector3 transformX = transform.position;
            Debug.Log(transformX);


            skillOneCooldown = false;
            onw1 = skillOne;
        }
        else
        {
            if (skillOneCooldown == false)
            {
                Debug.Log("첫번째 스킬은 쿨타임 입니다");
            }
            else if (Movement2D.isObj == false)
            {
                Debug.Log("스킬 사용 가능 지역이 아닙니다");

            }

        }
    }

}
