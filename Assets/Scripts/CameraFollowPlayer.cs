using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{

    private float FollowSpeed = 2f;
    public Transform target;
    

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, target.position.z + 5);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}
