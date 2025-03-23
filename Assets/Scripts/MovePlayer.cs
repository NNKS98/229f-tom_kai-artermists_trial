using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] float maxSpeed = 5f;
    [SerializeField] float drag = 2f; // Adjust to control slowdown speed
    Rigidbody rb;
    public GameObject BulletPrefab;
    public Transform ShootPosition;

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
            rb.AddForce(Vector3.right * speed, ForceMode.Acceleration);
        }

        if(rb.angularVelocity.magnitude > maxSpeed)
        {
            rb.angularVelocity = rb.angularVelocity.normalized * maxSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(BulletPrefab, ShootPosition.transform.position, ShootPosition.transform.rotation);
        }

        if(Input.GetKey(KeyCode.C))
        {
            rb.linearDamping = 5f;
        }

        else
        {
            rb.linearDamping = 0f;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
