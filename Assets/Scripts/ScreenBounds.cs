using UnityEngine;

public class ScreenBounds : MonoBehaviour
{
    private void Start()
    {
        EdgeCollider2D edgeCollider2D = gameObject.AddComponent<EdgeCollider2D>();

        Vector2[] points = new Vector2[5];

        float screenWidth = Camera.main.aspect * Camera.main.orthographicSize;
        float screenHeight = Camera.main.orthographicSize;

        points[0] = new Vector2(-screenWidth, screenHeight);
        points[1] = new Vector2(screenWidth, screenHeight);
        points[2] = new Vector2(screenWidth, -screenHeight);
        points[3] = new Vector2(-screenWidth, -screenHeight);
        points[4] = points[0];

        edgeCollider2D.points = points;
    }
}
