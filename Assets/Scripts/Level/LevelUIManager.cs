using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUIManager : MonoBehaviour
{
    [Header("Lose panel")]
    [SerializeField] private GameObject losePanel;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button menuLoseButton;

    [Space(5)]

    [Header("Menu panel")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button backToMenuButton;

    [Space(5)]

    [Header("Level UI")]
    [SerializeField] private Button menuButton;
    [SerializeField] private Text scoreText;

    public void Initialize()
    {
        ButtonFunc();

        Debug.Log("UI initialize");
    }

    private void ButtonFunc()
    {
        #region LosePanel
        if (restartButton != null)
        {
            restartButton.onClick.RemoveAllListeners();
            restartButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(1);
                Time.timeScale = 1;
            });
        }
        if (menuLoseButton != null)
        {
            menuLoseButton.onClick.RemoveAllListeners();
            menuLoseButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1;
            });
        }
        #endregion

        #region MenuPanel
        if (continueButton != null)
        {
            continueButton.onClick.RemoveAllListeners();
            continueButton.onClick.AddListener(() =>
            {
                menuPanel.SetActive(false);
                Time.timeScale = 1;
            });
        }
        if (backToMenuButton != null)
        {
            backToMenuButton.onClick.RemoveAllListeners();
            backToMenuButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1;
            });
        }
        #endregion
        if (menuButton != null)
        {
            menuButton.onClick.RemoveAllListeners();
            menuButton.onClick.AddListener(() =>
            {
                Time.timeScale = 0;
                menuPanel.SetActive(true);
            });
        }
    }

    public void AddScore(int score)
    {
        scoreText.text = "" + score;
    }

    public void LoseGame()
    {
        Time.timeScale = 0;
        losePanel.SetActive(true);
    }
}
