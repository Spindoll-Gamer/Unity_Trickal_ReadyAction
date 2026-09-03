using UnityEngine;
using UnityEngine.SceneManagement;
public class MainSceneManager : MonoBehaviour
{
    public void LoadToStageScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StageScene");
    }
}
