using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;
    public bool introMode = true;
    public float introSpeed = 2f;

    void Update()
    {
        Vector3 pos = transform.position;

        if (introMode)
        {
            pos.y += introSpeed * Time.deltaTime;
        }
        else
        {
            pos.y = Mathf.Lerp(pos.y, target.position.y, speed * Time.deltaTime);
        }

        transform.position = pos;
    }
}