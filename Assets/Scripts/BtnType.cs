using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BtnType : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    //마우스 버튼위에 올릴 시 버튼 크기 커지는 클래스
    //지금 사용 X 추후 사용
    public BTNType currentType;
    public Transform buttonScale;
    Vector3 defaultScale;
    void Start()
    {
        defaultScale = buttonScale.localScale;
    }

    // Update is called once per frame
    void Update()
    {
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
}
