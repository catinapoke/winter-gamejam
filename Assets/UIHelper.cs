using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHelper : MonoBehaviour
{
    public void LoadGameplay()
    {
        SceneManager.LoadScene(GameHelper.MAIN_SCENE_NAME);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
