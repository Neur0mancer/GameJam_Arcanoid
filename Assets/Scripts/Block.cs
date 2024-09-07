using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private Color[] _color;

    public BlockType BlockType;
    private SpriteRenderer _spriteRenderer;
    
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateBlockState();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            TakeDamage();
        }
    }
    private void TakeDamage()
    {
        BlockType--;
        if(BlockType == BlockType.Default)
        {
            GameManager.Instance.DecreaceBlockCount();
            GameManager.Instance.AddScore();
            Destroy(gameObject);
        }
        else
        {
            UpdateBlockState();
        }
    }
    private void UpdateBlockState()
    {
        switch (BlockType)
        {
            case BlockType.Default:
                _spriteRenderer.color = _color[0];
                Destroy(gameObject);
                GameManager.Instance.DecreaceBlockCount();
                break;
            case BlockType.One:
                _spriteRenderer.color = _color[1];
                break;
            case BlockType.Two:
                _spriteRenderer.color = _color[2];
                break;
            case BlockType.Three:
                _spriteRenderer.color = _color[3];
                break;
            case BlockType.Four:
                _spriteRenderer.color = _color[4];
                break;
        }
    }
   
}
