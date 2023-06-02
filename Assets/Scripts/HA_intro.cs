using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HA_intro : MonoBehaviour
{
    public Image[] images;
    private int currentIndex = 0;

    private void Start()
    {
        ShowImage(currentIndex); // 시작 시 첫 번째 이미지 보여주기
    }
    public void BtnSkip()
    {
        SceneManager.LoadScene("HA_tutorialScene");
    }

    public void NextButtonClicked()
    {
        currentIndex++; // 다음 이미지 인덱스 증가

        // 마지막 이미지를 넘어가면 첫 번째 이미지로 돌아감
        if (currentIndex >= images.Length)
        {
            SceneManager.LoadScene("HA_tutorialScene");
        }

        ShowImage(currentIndex); // 현재 이미지 보여주기
    }

    private void ShowImage(int index)
    {
        // 모든 이미지를 비활성화
        foreach (Image image in images)
        {
            image.gameObject.SetActive(false);
        }

        // 현재 인덱스에 해당하는 이미지를 활성화
        if(! (currentIndex == images.Length))
            images[index].gameObject.SetActive(true);
        else
        {
            images[index-1].gameObject.SetActive(true);
        }
    }
}
