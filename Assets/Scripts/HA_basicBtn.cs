using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class HA_basicBtn : MonoBehaviour
{
    public GameObject popupOption;
    public GameObject popupStage;
    //public GameObject popup;

    public GameObject Option_BGN;
    public GameObject Main;

    public AudioSource BtnAudio;

    public void GameStart()
    {
        Invoke("GameStart_Invoke", 1.0f);
    }

    public void GameStart_Invoke()
    {
        SceneManager.LoadScene("HA_introScene");
    }

    public void PopupOptionOn()
    {
        popupOption.SetActive(true);
    }

    public void PopupOptionOff()
    {
        popupOption.SetActive(false);
    }

    public void PopupStageOn()
    {
        popupStage.SetActive(true);
    }

    public void Stage1On()
    {
        SceneManager.LoadScene("HA_tutorialScene");
    }

    public void Stage2On()
    {
        SceneManager.LoadScene("HA_stage1");
    }

    public void PopupStageOff()
    {
        popupStage.SetActive(false);
    }

    public void BtnRestart()
    {
        SceneManager.LoadScene("HA_introScene");
    }

    public void BtnOption_option()
    {
        Option_BGN.SetActive(true);
    }
    public void BtnOption_optionBack()
    {
        Option_BGN.SetActive(false);
    }
}
