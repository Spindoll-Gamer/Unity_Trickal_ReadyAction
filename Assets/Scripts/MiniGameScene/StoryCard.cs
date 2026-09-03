using UnityEngine;
using UnityEngine.EventSystems;

public class StoryCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private int cardID; 
    public int CardID { get { return cardID; } }
    public CardSlot currentSlot;
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!MiniGameManager.instance.isTimerRunning) { return; }
        canvasGroup.blocksRaycasts = false;//CanvasGroup이라는 컴포넌트를 쓰면 blocksRaycasts를 사용할수 있는데 이건 이미지가 내 마우스의 레이캐스트를 못막게 하는것
        transform.SetParent(canvas.transform);
    }

    public void OnDrag(PointerEventData eventData)
    { 
        if(!MiniGameManager.instance.isTimerRunning) { return; }
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        if (transform.parent.GetComponent<CardSlot>() == null)
        {
            rectTransform.position = currentSlot.transform.position;
            currentSlot.EquipCard(this);
        }
    }
}
