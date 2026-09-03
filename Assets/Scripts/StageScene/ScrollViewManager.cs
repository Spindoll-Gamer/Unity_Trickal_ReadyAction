using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Reflection;

public class ScrollViewManager : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField]private float scrollSpeed = 10f;
    [SerializeField] public bool isAutoScrolling;

    private RectTransform contentRect;
    private HorizontalLayoutGroup layoutGroup;

    private FieldInfo m_ContentStartPositionField;
    public void Awake()
    {
        contentRect = GetComponent<RectTransform>();
        layoutGroup = GetComponent<HorizontalLayoutGroup>();

        if (scrollRect == null) scrollRect = GetComponentInParent<ScrollRect>();

        m_ContentStartPositionField = typeof(ScrollRect).GetField("m_ContentStartPosition", BindingFlags.NonPublic | BindingFlags.Instance);
    }
    private void Update()
    {
        bool isAutoScrolling = !(Input.GetMouseButton(0));
        if (isAutoScrolling) 
        { 
            contentRect.anchoredPosition += Vector2.left * scrollSpeed * Time.deltaTime;
        }
    }
    private void LateUpdate()
    {
        LoopPosters();
    }
    private void LoopPosters()
    {
        if (transform.childCount == 0) return;
        RectTransform firstChild = transform.GetChild(0) as RectTransform;
        
        if (firstChild == null) return;
        float posterSize = firstChild.rect.width + (layoutGroup != null ? layoutGroup.spacing : 0f);

        if (contentRect.anchoredPosition.x <= -posterSize)
        {
            firstChild.SetAsLastSibling();
            contentRect.anchoredPosition += new Vector2(posterSize, 0f);
            SetcontentRectAnchor(posterSize);
            LayoutRebuilder.ForceRebuildLayoutImmediate(contentRect);
        }//¿ÞÂÊ
        
        else if (contentRect.anchoredPosition.x > 0)
        {
            RectTransform lastChild = transform.GetChild(transform.childCount - 1) as RectTransform;
            if (lastChild != null)
            {
                lastChild.SetAsFirstSibling();
                contentRect.anchoredPosition -= new Vector2(posterSize, 0f);
                SetcontentRectAnchor(-posterSize);
                LayoutRebuilder.ForceRebuildLayoutImmediate(contentRect);
            }
        }//¿À¸¥ÂÊ
    }

    private void SetcontentRectAnchor(float deltaX)
    {
        if (scrollRect == null || m_ContentStartPositionField == null) return;
        Vector2 startPos = (Vector2)m_ContentStartPositionField.GetValue(scrollRect);
        startPos.x += deltaX;
        m_ContentStartPositionField.SetValue(scrollRect, startPos);
    }
}
