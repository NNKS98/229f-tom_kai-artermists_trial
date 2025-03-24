using System.Runtime.CompilerServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public float force;
    public float mass;
    public float acc;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Shoot();
        Destroy(gameObject ,2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Enemy")
        {
            Destroy(gameObject);
            var enemyRb = other.gameObject.GetComponent<Rigidbody>();
            enemyRb.AddForce(Vector3.right * 5, ForceMode.Impulse);
            Destroy(other.collider);
        }
    }

    void Shoot()
    {
        mass = GetComponent<Rigidbody>().mass;
        force = mass * acc;
        rb.AddForce(Vector3.right * force, ForceMode.Impulse);
        //rb.AddForce(force, force, 0);
    }
}
