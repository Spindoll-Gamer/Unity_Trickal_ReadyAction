using UnityEngine;
using UnityEngine.SceneManagement;
public class StageSceneManager : MonoBehaviour
{
    public void LoadToMainScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }

    public void LoadToMiniGameScene()
    {
        GameDataReceiver.instance.PackStageData(StageUIManager.instance.currentStage);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MiniGameScene");
    }
}
