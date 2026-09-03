using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PosterUI : MonoBehaviour
{
    private StageData stageData;
    public void Setup(StageData data)
    {
        if (data != null)
        {
            stageData = data;
            Image image = gameObject.GetComponent<Image>();
            image.sprite = stageData.stagePosterSprite;
            Button button = GetComponent<Button>();

            if (button != null)
            {
                button.onClick.AddListener(OnClickPoster);
            }
        }
    }
    public void OnClickPoster()
    {
        if (StageUIManager.instance != null)
        {
            StageUIManager.instance.StageSelected(stageData);
        }
    }
}
