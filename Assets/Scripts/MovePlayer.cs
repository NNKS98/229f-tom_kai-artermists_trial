using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] float drag = 2f; // Adjust to control slowdown speed
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.linearDamping = drag; // Apply drag to slow down naturally
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.right * speed, ForceMode.Acceleration);
        }
    }
}
