using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] float acceleration = 2f;
    [SerializeField] float maxSpeed = 5f; 
    [SerializeField] float deceleration = 1f;
    [SerializeField] float drag = 2f; 
    [SerializeField] float jumpForce = 1f;
    private bool canJump = false;
    private float currentSpeed = 0f;
    private Rigidbody rb;

    public GameObject BulletPrefab;
    public Transform ShootPosition;

    [SerializeField] int playerHp;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.linearDamping = drag;
        canJump = true;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            currentSpeed += acceleration;
            currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        }

        
        if (!Input.GetKey(KeyCode.D))
        {
            currentSpeed -= deceleration * Time.deltaTime;
            currentSpeed = Mathf.Max(0, currentSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            canJump = false;
        }
        
        // Move the object using velocity (translation instead of rotation)
        rb.linearVelocity = new Vector3(currentSpeed, rb.linearVelocity.y, rb.linearVelocity.z);

        // Limit max angular velocity
        if (rb.angularVelocity.magnitude > maxSpeed)
        {
            rb.angularVelocity = rb.angularVelocity.normalized * maxSpeed;
        }

        // Shooting
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(BulletPrefab, ShootPosition.transform.position, ShootPosition.transform.rotation);
        }

        // Adjust damping dynamically (e.g., crouching)
        if (Input.GetKey(KeyCode.C))
        {
            rb.linearDamping = 5f; // Higher friction when crouching
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

        if (other.gameObject.CompareTag("RedFloor"))
        {
            rb.linearDamping *= 2f; // Reduce friction on red floor
            canJump = true;
            maxSpeed = 5f;
        }

        if (other.gameObject.CompareTag("BlueFloor"))
        {
            rb.linearDamping *= 0.25f;
            canJump = true;
            maxSpeed = 20f;
        }

        if (other.gameObject.CompareTag("NormalFloor"))
        { 
            canJump = true;
            maxSpeed = 10f;
        }

    }
}
