using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HA_stage2UI : MonoBehaviour
{
    public GameObject UI_chatWindow;
    public GameObject chat;
    public GameObject UI_skil;
    public GameObject UI_skilEffect;
    public GameObject btn_option;
    public GameObject btn_skip;
    public GameObject btn_next;
    public TextMeshProUGUI txt;

    public GameObject popupOption;
    public GameObject popupStage;

    public string[] chatTxt;
    public int index = 0;

    public bool skilUse;

    void Start()
    {
        try
        {
            txt = chat.GetComponent<TextMeshProUGUI>();
            UI_skilEffect.SetActive(false);
            UI_chatWindow.SetActive(false);

            chatTxt = new string[3];
            chatTxt[0] = "여기 저기 금이 간 신상이야.";
            chatTxt[1] = "외부로부터 충격을 받은 것 말고도 오랜 시간이 지난 채로 방치된 것 같아.";
        } catch { }
    }

    void Update()
    {
        txt.text = chatTxt[index];
        if (index == 2)
        {
            UI_chatWindow.SetActive(false);
        }

        if (skilUse)
        {
            UI_skilEffect.SetActive(true);
            Invoke("skilUsed", 2f);
            skilUse = false;
        }
    }

    public void btnNext()
    {
        index++;
    }

    public void btnSkip()
    {
        index = 2;
    }

    public void skilUsed()
    {
        UI_skilEffect.SetActive(false);
    }

    public void btnOption()
    {
        popupOption.SetActive(true);
    }
    public void btnOption_main()
    {
        SceneManager.LoadScene("HA_titleScene");
    }
    public void btnOption_restart()
    {
        SceneManager.LoadScene("HA_stage1");
    }
    public void btnOption_stage()
    {
        popupStage.SetActive(true);
    }
    public void btnOption_option()
    {

    }
    public void btnOption_exit()
    {
        popupOption.SetActive(false);
    }

    public void btnOption_stage_stage1()
    {
        SceneManager.LoadScene("HA_tutorialScene");
    }
    public void btnOption_stage_stage2()
    {
        SceneManager.LoadScene("HA_stage1");
    }
    public void btnOption_stage_exit()
    {
        popupStage.SetActive(false);
    }
}
