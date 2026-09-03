using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
using System;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager instance { get; private set; }

    [SerializeField] public GameObject slate;
    [SerializeField] public GameObject timer;
    public float timerTime;
    public TextMeshProUGUI timerText;
    public bool isTimerRunning = false;

    public List<StoryCard> cards = new List<StoryCard>();
    public List<CardSlot> cardSlots = new List<CardSlot>();
    private void Awake()
    {
        if ( instance == null )
        {
            instance = this; 
        }
        else 
        {
            Destroy(gameObject); 
        }

        List<Sprite> spriteData = GameDataReceiver.instance.spriteData;
        timerTime = GameDataReceiver.instance.timerTime;

        for(int i  = 0; i < cards.Count; i++)
        {
            Image cardImage = cards[i].GetComponent<Image>();
            cardImage.sprite = spriteData[i];
        }
        timerText = timer.GetComponent<TextMeshProUGUI>();
        timerText.text = timerTime.ToString("F2");

        ShuffleList(cards);
        CardSet();
    }
    void Start()
    {
        StartCoroutine("ReadyToStart");
    }


    // Update is called once per frame
    void Update()
    {
        if (!isTimerRunning) return;

        timerTime -= Time.deltaTime;

        if (timerTime < 0)
        {
            timerTime = 0;
            isTimerRunning = false;
            TimeOver();
        }
        timerText.text = timerTime.ToString("F2");
    }

    private void TimeOver()
    {
        DropCard();

        for (int i = 0; i < cards.Count; i++)
        {
            if (cardSlots[i].SlotID != cardSlots[i].currentCard.CardID)
            {
                Debug.Log("실패");
                return;
            }
        }
        Debug.Log("성공");
    }

    IEnumerator ReadyToStart()
    {
        slate.SetActive(true);
        yield return new WaitForSeconds(3f);
        TextMeshProUGUI slateText = slate.GetComponentInChildren<TextMeshProUGUI>();
        slateText.text = "Action!";
        yield return new WaitForSeconds(1f);
        slate.SetActive(false);
        isTimerRunning = true;
    }

    public void ShuffleList<T>(List<T> list)
    {
        int count = list.Count;
        while (count > 1)
        {
            count--;
            int randomNumber = UnityEngine.Random.Range(0, count + 1);

            T item = list[randomNumber];
            list[randomNumber] = list[count];
            list[count] = item;
        }
    }

    public void CardSet()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].transform.SetParent(cardSlots[i].transform);
            cardSlots[i].EquipCard(cards[i]);
            cards[i].currentSlot = cardSlots[i];
        }
    }
    public void DropCard()
    {
        foreach(StoryCard card in cards)
        {
            PointerEventData fakeData = new PointerEventData(EventSystem.current);
            card.OnEndDrag(fakeData);
        }
    }
}
