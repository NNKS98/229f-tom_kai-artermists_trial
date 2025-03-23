using UnityEngine;

public class WindZone : MonoBehaviour
{
    [SerializeField] float windForce = 0f;

    private void OnTriggerStay(Collider other)
    {
        var hitObj = other.gameObject;
        if (hitObj != null )
        {
            var rb = hitObj.GetComponent<Rigidbody>();
            var dir = Vector3.left;
            rb.AddForce(dir * windForce);
        }
    }
}
