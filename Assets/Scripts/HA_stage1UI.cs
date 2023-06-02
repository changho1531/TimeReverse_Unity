using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HA_stage1UI : MonoBehaviour
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
    public GameObject popupBGM;

    public string[] chatTxt;
    public int index = 0;

    public bool skilUse;

    void Start()
    {
        txt = chat.GetComponent<TextMeshProUGUI>();
        UI_skilEffect.SetActive(false);

        chatTxt = new string[4];
        chatTxt[0] = "어지러워, 여긴 어디지? 숲인 것 같은데. 어딘가 익숙해...";
        chatTxt[1] = "모래시계. 맞아, 샬리가 나를...";
        chatTxt[2] = "여기서 계속 이렇게 서있을 수는 없지. 이동해야겠어.";
    }

    void Update()
    {
        txt.text = chatTxt[index];
        if(index == 3)
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
        index = 3;
    }

    public void skilUsed()
    {
        Debug.Log("여기야!");
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
        SceneManager.LoadScene("HA_tutorialScene");
    }
    public void btnOption_stage()
    {
        popupStage.SetActive(true);
    }
    public void btnOption_option()
    {
        popupBGM.SetActive(true);
    }
    public void btnOption_optionBack()
    {
        popupBGM.SetActive(false);
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
