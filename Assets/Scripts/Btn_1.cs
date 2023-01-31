using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btn_1 : MonoBehaviour
{
    public GameObject subMenuSet;
    public GameObject optionSet;
    public GameObject menuSet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuSet.activeSelf)
            {
                menuSet.SetActive(false);
            }
            else
                menuSet.SetActive(true);
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
