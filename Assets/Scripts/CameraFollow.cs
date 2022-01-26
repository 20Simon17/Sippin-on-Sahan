using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()

    {
        Vector3 targetPosision = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosision, smoothFactor * Time.fixedDeltaTime);
        transform.position = targetPosision;
    }
}

