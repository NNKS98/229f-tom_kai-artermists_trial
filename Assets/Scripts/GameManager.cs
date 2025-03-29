using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Rigidbody target;
    [SerializeField] TextMeshProUGUI currentSpeed;
    [SerializeField] TextMeshProUGUI currentPlayerHp;
    [SerializeField] MovePlayer player;
    [SerializeField] GameObject gameoverScreen;
    [SerializeField] GameObject gamerWinScreen;

    private void Awake()
    {
        gameoverScreen.SetActive(false);
        gamerWinScreen.SetActive(false);
    }

    void Update()
    {
        currentSpeed.text = "Speed: " + target.linearVelocity.x.ToString();
        currentPlayerHp.text = "HP: " + player.playerHp;

        if (player.playerHp <= 0)
        {
            gameoverScreen.SetActive(true);
        }
    }

    public void GameOver()
    {
        //Time.timeScale *= 0;
        gameoverScreen.SetActive(true);
    }

    public void GameWin()
    {
        //Time.timeScale *= 0;
        gamerWinScreen.SetActive(true);
    }

    public void Restart()
    {
        var s = SceneManager.GetActiveScene();
        SceneManager.LoadScene(s.name);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
