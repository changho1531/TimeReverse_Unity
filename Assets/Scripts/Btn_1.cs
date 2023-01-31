using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btn_1 : MonoBehaviour
{
    public GameObject subMenuSet;   // 내부 메뉴창
    public GameObject optionSet;   // 옵션창
    public GameObject menuSet;   // 메뉴 창
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Debug.Log("눌렀어");
        //    if (menuSet.activeSelf)
        //    {
        //        menuSet.SetActive(false);
        //    }
        //    else
        //    {
        //        menuSet.SetActive(true);
        //    }
        //}
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("눌렀어");
            if (menuSet.activeSelf)
            {
                menuSet.SetActive(false);
            }
            else if(!menuSet.activeSelf)
            {
                if(optionSet.activeSelf) 
                {
                    optionSet.SetActive(false);
                }
                menuSet.SetActive(true);
                subMenuSet.SetActive(true);
            }
        }

    }


    public void OnBtnOption()
    {
        Debug.Log("옵션 버튼 클릭");
        if (subMenuSet)
        {
            optionSet.SetActive(true);
            if(optionSet)
            {
                subMenuSet.SetActive(false);
            }
        }
    }
    public void OnBack()
    {
        Debug.Log("뒤로가기 버튼을 눌렀습니다");
        if (optionSet)
        {
            subMenuSet.SetActive(true);
            if (subMenuSet)
            {
                optionSet.SetActive(false);
            }
        }
    }
    public void Reset()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainScenes");
    }
}
