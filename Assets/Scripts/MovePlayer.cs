using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] int speed;
    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.right * speed, ForceMode.Impulse);
        }
        else
        {
            rb.linearVelocity = Vector3.zero; // Stops movement when the key is released
        }
    }
}
