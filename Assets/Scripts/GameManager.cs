using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject mainMenuScreen;
    [SerializeField] GameObject instructionsScreen;
    [SerializeField] Slider rowsSlider;
    [SerializeField] Slider colsSlider;
    [SerializeField] TextMeshProUGUI rowsText;
    [SerializeField] TextMeshProUGUI colsText;
    public int Lives {  get; private set; }
    public Ball ball;
    public int blocksCount;

    private int _score;
    private LevelGenerator _levelGenerator;
    private int _rowsSliderValue;
    private int _colsSliderValue;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
        ResetValues();
        winScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        instructionsScreen.SetActive(false);
        _levelGenerator = GetComponent<LevelGenerator>();

        Time.timeScale = 0f;
    }
    private void Start()
    {
        rowsSlider.onValueChanged.AddListener(UpdateRowsNumber);
        colsSlider.onValueChanged.AddListener(UpdateColsNumber);
        rowsText.text = rowsSlider.value.ToString();
        colsText.text = colsSlider.value.ToString();
    }
    public void DecreaseLife()
    {
        Lives--;
        livesText.text = "x  " + Lives;
        if(Lives > 0)
        {
            ball.ResetBallPos();
        }
        else
        {
            GameOver();
        }
    }
    private void GameOver()
    {
        Debug.Log("Game Over");
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f; 
    }
    public void DecreaceBlockCount()
    {
        blocksCount--;
        if(blocksCount <= 0)
        {
            Win();
        }
    }
    private void Win()
    {
        Debug.Log("Win");
        winScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    public void AddScore()
    {
        _score += 100;
        scoreText.text = _score.ToString();
    }
    public void RestartLevel()
    {
        ResetValues();
        Time.timeScale = 1f;
        _rowsSliderValue = (int)rowsSlider.value;
        _colsSliderValue = (int)colsSlider.value;
        _levelGenerator.GenerateLevel(_rowsSliderValue, _colsSliderValue);
        ball.ResetBallPos();

        instructionsScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        winScreen.SetActive(false );
    }
    public void MainMenu()
    {
        mainMenuScreen.SetActive(true);
        gameOverScreen.SetActive(false);
        winScreen.SetActive(false);
    }
    public void Play()
    {
        mainMenuScreen.SetActive(false);
        instructionsScreen.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
    private void ResetValues()
    {
        Lives = 3;
        blocksCount = 0;
        _score = 0;
        livesText.text = "x  " + Lives;
        scoreText.text = _score.ToString();
    }
    private void UpdateRowsNumber(float value)
    {
        rowsText.text = value.ToString();
    }
    private void UpdateColsNumber(float value)
    {
        colsText.text = value.ToString();
    }
}
