using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class StageUIManager : MonoBehaviour
{ 
    public static StageUIManager instance { get; private set; }

    [Header("스테이지 선택")]
    public List<StageData> stageInfo = new List<StageData>();

    [Header("UI 연결")]
    public GameObject PosterPrefab;
    public Transform scrollContent;

    public GameObject stageTitleImage;
    public GameObject stageText;
    public GameObject gameStartButton;
    public StageData currentStage;
    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RefreshPoster();
    }

    public void RefreshPoster()
    {
        foreach (Transform child in scrollContent) { Destroy(child.gameObject); }

        foreach (StageData data in stageInfo)
        {
            if (data == null) continue;
            GameObject newPoster = Instantiate(PosterPrefab, scrollContent);
            newPoster.GetComponent<PosterUI>().Setup(data);
        }
    }
    public void StageSelected(StageData stageData)
    {
        currentStage = stageData;
        stageTitleImage.SetActive(true);
        stageTitleImage.GetComponent<Image>().sprite = stageData.stageTitleSprite;
        stageText.SetActive(true);
        stageText.GetComponent<TextMeshProUGUI>().text = stageData.text;
        gameStartButton.SetActive(true);
    }
}
