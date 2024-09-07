using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Transform paddleTransform;
    public float speed = 5f;

    private Rigidbody2D _rb;
    private bool _isLaunched = false;
    private Vector3 _offset;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _offset = transform.position - paddleTransform.position;
        ResetBallPos();
    }
    private void FixedUpdate()
    {
        _rb.velocity = _rb.velocity.normalized * _rb.velocity.magnitude;
        if(! _isLaunched )
        {
            transform.position = paddleTransform.position + _offset;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {        
        if (collision.gameObject.CompareTag("Paddle"))
        {
            HandlePaddleCollision(collision);
        }        
    }
    public void LauchBall()
    {
        if (!_isLaunched)
        {
            Vector2 launchDirection = new Vector2(Random.Range(-1f, 1f), 1f).normalized;
            _rb.velocity = launchDirection * speed;
            _isLaunched = true;
        }
    }
    private void HandlePaddleCollision(Collision2D collision)
    {
        
        Vector3 paddlePosition = collision.transform.position;
        Vector3 ballPosition = transform.position;
        float difference = ballPosition.x - paddlePosition.x;
        Vector2 newDir = new Vector2(difference, 1).normalized;

        _rb.velocity = newDir * speed;
        
    }
    public void ResetBallPos()
    {
        _isLaunched = false;
        _rb.velocity = Vector3.zero;
        transform.position = paddleTransform.position + _offset;
    }
}
