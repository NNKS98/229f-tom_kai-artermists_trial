using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Animation collisionAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
