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
        mass = GetComponent<Rigidbody>().mass;
    }
    
    void Start()
    {
        Shoot();
        Destroy(gameObject ,2);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            //var enemyRb = other.gameObject.GetComponent<Rigidbody>();
            //enemyRb.AddForce(Vector3.right * 5, ForceMode.Impulse);
            Destroy(other.gameObject);
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
