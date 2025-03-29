using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void Credit()
    {
        SceneManager.LoadSceneAsync("CreditScene");
    }
}
