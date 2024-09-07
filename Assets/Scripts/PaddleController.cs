using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] Ball mainBall;

    public float moveSpeed = 0.1f;  

    private PlayerControls _controls;
    private Vector2 _moveInput;
    private Rigidbody2D _rb;
    private float _screenSizeHalfInUnits;
    private float _halfPaddle;
    

    private void Awake()
    {
        _controls = new PlayerControls();
        _controls.Enable();
        _controls.Gameplay.Move.performed += ctx => _moveInput = ctx.ReadValue<Vector2>();
        _controls.Gameplay.Move.canceled += ctx => _moveInput = Vector2.zero;
        _controls.Gameplay.Launch.performed += ctx => mainBall.LauchBall();
    }    
    private void OnEnable()
    {
        _controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        _controls.Gameplay.Disable();
    }
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _screenSizeHalfInUnits = Camera.main.aspect * Camera.main.orthographicSize;
        _halfPaddle = transform.localScale.x / 2f;

    }
    private void Update()
    {
        MovePaddle();
    }
    private void MovePaddle()
    {
        Vector2 currentPos = _rb.position;
        currentPos += _moveInput * moveSpeed * Time.deltaTime;
        float clampedX = Mathf.Clamp(currentPos.x, -_screenSizeHalfInUnits + _halfPaddle, _screenSizeHalfInUnits - _halfPaddle);

        _rb.MovePosition(new Vector2(clampedX, currentPos.y));
    }
}
