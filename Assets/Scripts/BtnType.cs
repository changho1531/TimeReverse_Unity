using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BtnType : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public BTNType currentType;
    public Transform buttonScale;
    Vector3 defaultScale;
    bool isSound;
    //public CanvasGroup mainGroup;
    //public CanvasGroup optionGroup;
    public GameObject OptionSet;
    void Start()
    {
        defaultScale = buttonScale.localScale;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnBtnClick()
    {
        if (Input.GetButtonDown("배경음악"))
        {
            Debug.Log("배경음악버튼을눌렀스빈다");

        }
        switch (currentType)
        {
            case BTNType.New:
                Debug.Log("메인화면");
                break;
            case BTNType.Continue:
                Debug.Log("다시하기");
                break;
            case BTNType.Option:
                Debug.Log("옵션");
                break;
            case BTNType.Sound:
                Debug.Log("사운드");
                break;
            case BTNType.Back:
                Debug.Log("뒤로가기");
                break;
            case BTNType.Quit:
                Debug.Log("나가기");
                //CanvasGroupOff(mainGroup);
                //CanvasGroupOff(optionGroup);
                break;
        }
    }

    //스크립트가 붙어있는 오브젝트에 마우스가 닿으면 함수 호출
    //버튼의 크기가 커진다
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.1f;
    }

    //마우스가 오브젝트에서 벗어나면 호출
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }

    public void CanvasGroupOn(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }  
    public void CanvasGroupOff(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
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
