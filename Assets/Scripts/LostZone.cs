using UnityEngine;

public class LostZone : MonoBehaviour
{    
    void Start()
    {
        BoxCollider2D boxColiider = GetComponent<BoxCollider2D>();

        float screenWidth = Camera.main.aspect * Camera.main.orthographicSize * 2;

        Vector2 newSize = new Vector2(screenWidth, boxColiider.size.y);
        boxColiider.size = newSize;

        Vector3 newPos = new Vector3(0, -Camera.main.orthographicSize - boxColiider.size.y / 2, 0);
        transform.position = newPos;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")) 
        {
            GameManager.Instance.DecreaseLife();
        }
    }
}
