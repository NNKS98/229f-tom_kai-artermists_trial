using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] int speed;
    public float maxSpeed = 5f;
    [SerializeField] float drag = 2f; // Adjust to control slowdown speed
    Rigidbody rb;
    public GameObject BulletPrefab;
    public Transform ShootPosition;

    [SerializeField] int playerHp;

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
            rb.linearDamping = drag;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            playerHp -= 1;
            Destroy(other.gameObject);

            if (playerHp <= 0)
            {
                Destroy(gameObject);
            }
        }

        if(other.gameObject.CompareTag("RedFloor"))
        {
            //maxSpeed = 3f;
            rb.linearDamping *= 0.25f;
        }
    }
}
