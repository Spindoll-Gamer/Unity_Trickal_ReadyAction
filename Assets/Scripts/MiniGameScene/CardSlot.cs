using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSlot : MonoBehaviour, IDropHandler
{
    [SerializeField]private int slotID;
    public int SlotID { get { return slotID; } }
    public StoryCard currentCard;

    public void OnDrop(PointerEventData eventData)
    {
        if (!MiniGameManager.instance.isTimerRunning) { return; }

        if (eventData.pointerDrag != null)
        {
            StoryCard dropCard = eventData.pointerDrag.GetComponent<StoryCard>();

            if (dropCard != null)
            {
                if (currentCard != null) { ExchangeCard(dropCard); }
                EquipCard(dropCard);
            }
        }
    }

    private void ExchangeCard(StoryCard dropCard)
    {
        dropCard.currentSlot.EquipCard(currentCard);
        this.EquipCard(dropCard);
    }

    public void EquipCard(StoryCard dropCard)
    {
        currentCard = dropCard;
        dropCard.transform.SetParent(this.transform);
        RectTransform cardRect = dropCard.GetComponent<RectTransform>();
        cardRect.anchoredPosition = Vector2.zero;
        dropCard.currentSlot = this;
    }
}
