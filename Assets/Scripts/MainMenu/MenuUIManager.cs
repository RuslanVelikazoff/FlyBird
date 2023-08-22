using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    [Header("MainPanel")]
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Text scoreText;

    [Header("SettingsPanel")]
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Button easyLevelButton;
    [SerializeField] private Text easyLevelText;
    [SerializeField] private Button midleLevelButton;
    [SerializeField] private Text midleLevelText;
    [SerializeField] private Button hardLevelButton;
    [SerializeField] private Text hardLevelText;
    [SerializeField] private Button backMenuButton;

    private MenuData data;

    public void Initialize()
    {
        data = FindObjectOfType<MenuData>();

        ButtonFunc();
        SetDifficulty();
        SetVolumeSlider();
        ScoreInitialize();

        Debug.Log("Menu UI initialized");
    }

    private void Update()
    {
        UpdateVolumeSlider();
    }

    private void ButtonFunc()
    {
        #region MainPanel
        if (playButton != null)
        {
            playButton.onClick.RemoveAllListeners();
            playButton.onClick.AddListener(() =>
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(1);
            });
        }
        if (settingsButton != null)
        {
            settingsButton.onClick.RemoveAllListeners();
            settingsButton.onClick.AddListener(() =>
            {
                settingsPanel.SetActive(true);
                Debug.Log("Settings button");
            });
        }
        if (exitButton != null)
        {
            exitButton.onClick.RemoveAllListeners();
            exitButton.onClick.AddListener(() =>
            {
                Application.Quit();
                Debug.Log("Quit");
            });
        }
        #endregion
        #region SettingsPanel
        if (backMenuButton != null)
        {
            backMenuButton.onClick.RemoveAllListeners();
            backMenuButton.onClick.AddListener(() =>
            {
                mainPanel.SetActive(true);
                settingsPanel.SetActive(false);
            });
        }

        if (easyLevelButton != null)
        {
            easyLevelButton.onClick.RemoveAllListeners();
            easyLevelButton.onClick.AddListener(() =>
            {
                Debug.Log("Easy");
                data.easyLevel = true;
                data.midleLevel = false;
                data.hardLevel = false;
                SetDifficulty();
            });
        }

        if (midleLevelButton != null)
        {
            midleLevelButton.onClick.RemoveAllListeners();
            midleLevelButton.onClick.AddListener(() =>
            {
                Debug.Log("Midle");
                data.easyLevel = false;
                data.midleLevel = true;
                data.hardLevel = false;
                SetDifficulty();
            });
        }
        if (hardLevelButton != null)
        {
            hardLevelButton.onClick.RemoveAllListeners();
            hardLevelButton.onClick.AddListener(() =>
            {
                Debug.Log("Hard");
                data.easyLevel = false;
                data.midleLevel = false;
                data.hardLevel = true;
                SetDifficulty();
            });
        }
        #endregion

    }

    private void SetVolumeSlider()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }

    private void UpdateVolumeSlider()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);

        foreach (var s in AudioManager.Instance.sounds)
        {
            s.source.volume = s.volume = PlayerPrefs.GetFloat("Volume");

            if (s.name == "Music")
            {
                s.source.volume = s.volume = PlayerPrefs.GetFloat("MusicVolume");
            }
        }
    }

    private void SetDifficulty()
    {
        if (data.easyLevel)
        {
            easyLevelText.text = "!";
            data.easyLevel = true;
            midleLevelText.text = "";
            data.midleLevel = false;
            hardLevelText.text = "";
            data.hardLevel = false;
        }

        if (data.midleLevel)
        {
            easyLevelText.text = "";
            data.easyLevel = false;
            midleLevelText.text = "!";
            data.midleLevel = true;
            hardLevelText.text = "";
            data.hardLevel = false;
        }

        if (data.hardLevel)
        {
            easyLevelText.text = "";
            data.easyLevel = false;
            midleLevelText.text = "";
            data.midleLevel = false;
            hardLevelText.text = "!";
            data.hardLevel = true;
        }
    }

    private void ScoreInitialize()
    {
        scoreText.text = "Scores: " + data.highScore;
    }
}
