using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Poster", menuName = "ScriptableObjects/Poster")]
[System.Serializable]
public class StageData : ScriptableObject
{
    public Sprite stagePosterSprite;
    public Sprite stageTitleSprite;
    [TextArea] public string text;
    public List<Sprite> cardSprite;
    public float timerTime;
}