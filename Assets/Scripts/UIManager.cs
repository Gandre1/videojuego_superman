using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Image[] hearts;
    public GameObject gameOverText;
    public GameObject restartButton;
    public GameObject menuButton;
    public GameObject record;
    public GameObject score;
    public GameObject firstSelectedButton;
    public AudioSource audioSource;
    public AudioClip gameOverSound;
    public GameManager gameManager;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI finalScoreText;
    private bool played = false;
    private bool isPaused = false;

    public void UpdateLives(int currentLives)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < currentLives;
        }
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowGameOver()
    {
        gameOverText.SetActive(true);
        restartButton.SetActive(true);
        menuButton.SetActive(true);
        record.SetActive(true);
        score.SetActive(true);

        scoreText.gameObject.SetActive(false);

        ScoreManager.instance.StopCounting();
        ScoreManager.instance.CheckNewRecord();

        finalScoreText.text = ScoreManager.instance.GetMeters() + " m";
        bestScoreText.text = ScoreManager.instance.bestScore + " m";

        MenuState.firstSelectionDone = false;

        StartCoroutine(SelectButton());

        if (!played)
        {
            audioSource.PlayOneShot(gameOverSound);
            played = true;
        }
    }
    IEnumerator SelectButton()
    {
        yield return null;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(restartButton);
    }
    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (gameManager != null && gameManager.IsGameplay())
            {
                TogglePause();
            }
        }

        if ((isPaused || gameOverText.activeSelf) &&
            EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(firstSelectedButton);
        }

        scoreText.text = ScoreManager.instance.GetMeters() + " m";
    }

    void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }
    
    void PauseGame()
    {
        isPaused = true;

        Time.timeScale = 0f;

        restartButton.SetActive(true);
        menuButton.SetActive(true);

        gameOverText.SetActive(false);

        MenuState.firstSelectionDone = false;

        StartCoroutine(SelectButton());
    }
    void ResumeGame()
    {
        isPaused = false;

        Time.timeScale = 1f;

        restartButton.SetActive(false);
        menuButton.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
    }
}