using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 movement;
    private Camera cam;
    private float halfWidth;
    private float halfHeight;

    void Start()
    {
        cam = Camera.main;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        halfWidth = sr.bounds.extents.x;
        halfHeight = sr.bounds.extents.y;
    }

    void Update()
    {
        movement = Vector2.zero;

        if (Keyboard.current.wKey.isPressed) movement.y = 1;
        if (Keyboard.current.sKey.isPressed) movement.y = -1;
        if (Keyboard.current.aKey.isPressed) movement.x = -1;
        if (Keyboard.current.dKey.isPressed) movement.x = 1;

        Vector3 newPosition = transform.position + (Vector3)(movement.normalized * speed * Time.deltaTime);

        Vector3 min = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 max = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));

        newPosition.x = Mathf.Clamp(newPosition.x, min.x + halfWidth, max.x - halfWidth);
        newPosition.y = Mathf.Clamp(newPosition.y, min.y + halfHeight, max.y - halfHeight);

        transform.position = newPosition;
    }
}