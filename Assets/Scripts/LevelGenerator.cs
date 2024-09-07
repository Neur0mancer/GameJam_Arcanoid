using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject blockPrefab;

    private float _padding = 0.1f;
    private float _blockWidth;
    private float _blockHeight;
    private float _topOffset = 1f;

    
    public void GenerateLevel(int rows, int columns)
    {
        DestroyAllBlocks();
        float screenWidth = Camera.main.aspect * Camera.main.orthographicSize * 2; 
        float screenHeight = Camera.main.orthographicSize * 2;
        
        _blockWidth = (screenWidth - (_padding * (columns + 1))) / columns;
        _blockHeight = (screenHeight / 2 - (_padding * (rows + 1))) / rows;

        for(int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                float xPos = -screenWidth / 2 + _padding + (_blockWidth + _padding) * col + _blockWidth / 2;
                float yPos = screenHeight / 2 - _padding - (_blockHeight +_padding) * row - _blockHeight / 2 - _topOffset;

                GameObject newBlock = Instantiate(blockPrefab, new Vector2(xPos,yPos), Quaternion.identity);
                newBlock.transform.localScale = new Vector3(_blockWidth, _blockHeight, 1);
                Block blockScript = newBlock.GetComponent<Block>();
                blockScript.BlockType = (BlockType)Random.Range(0, 5);
                GameManager.Instance.blocksCount++;
            }
        }
    }
    public void DestroyAllBlocks()
    {
        Block[] blocks = FindObjectsOfType<Block>();
        foreach (Block block in blocks)
        {
            Destroy(block.gameObject);
        }
    }
}
