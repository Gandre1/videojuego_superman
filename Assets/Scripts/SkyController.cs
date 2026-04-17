using UnityEngine;

public class SkyScroller : MonoBehaviour
{
    public float speed = 2f;
    public int skyCount = 2;
    private float height;
    private bool isActive = false; 

    void Start()
    {
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        if (!isActive) return;

        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y <= Camera.main.transform.position.y - height)
        {
            transform.position += new Vector3(0, height * skyCount - 0.1f, 0);
        }
    }

    public void Activate()
    {
        isActive = true;
    }
}