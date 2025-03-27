using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] Rigidbody target;
    [SerializeField] TextMeshProUGUI currentSpeed;
    [SerializeField] TextMeshProUGUI currentPlayerHp;
    [SerializeField] MovePlayer player;

    void Update()
    {
        currentSpeed.text = "Speed: " + target.linearVelocity.x.ToString();
        currentPlayerHp.text = "HP: " + player.playerHp;
    }
}
