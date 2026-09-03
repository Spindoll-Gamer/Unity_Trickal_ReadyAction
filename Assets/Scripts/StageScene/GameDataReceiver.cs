using System.Collections.Generic;
using System.Threading;
using UnityEditor.U2D.Animation;
using UnityEngine;
public class GameDataReceiver : MonoBehaviour
{
    public static GameDataReceiver instance { get; private set; }

    public List<Sprite> spriteData;
    public float timerTime;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PackStageData(StageData data)
    {
        timerTime = data.timerTime;
        spriteData = data.cardSprite;
    }
}

