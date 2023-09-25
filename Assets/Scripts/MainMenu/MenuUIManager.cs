using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    [Header("MainPanel")]
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Text scoreText;

    [Header("SettingsPanel")]
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Button easyLevelButton;
    [SerializeField] private Text easyLevelText;
    [SerializeField] private Button midleLevelButton;
    [SerializeField] private Text midleLevelText;
    [SerializeField] private Button hardLevelButton;
    [SerializeField] private Text hardLevelText;
    [SerializeField] private Button backMenuButton;

    [SerializeField] private Button musicButton;
    [SerializeField] private Sprite musicOnSprite;
    [SerializeField] private Sprite musicOffSprite;

    [SerializeField] private Button soundButton;
    [SerializeField] private Sprite soundOnSprite;
    [SerializeField] private Sprite soundOffSprite;

    private MenuData data;

    public void Initialize()
    {
        data = FindObjectOfType<MenuData>();

        ButtonFunc();
        SetDifficulty();
        SetSoundSprite();
        SetMusicSprite();
        ScoreInitialize();

        Debug.Log("Menu UI initialized");
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

        if (musicButton != null)
        {
            musicButton.onClick.RemoveAllListeners();
            musicButton.onClick.AddListener(() =>
            {
                if (PlayerPrefs.GetFloat("MusicVolume") == 0)
                {
                    AudioManager.Instance.OnMusic();
                    SetMusicSprite();
                }
                else
                {
                    AudioManager.Instance.OffMusic();
                    SetMusicSprite();
                }
            });
        }

        if (soundButton != null)
        {
            soundButton.onClick.RemoveAllListeners();
            soundButton.onClick.AddListener(() =>
            {
                if (PlayerPrefs.GetFloat("SoundVolume") == 0)
                {
                    AudioManager.Instance.OnSound();
                    SetSoundSprite();
                }
                else
                {
                    AudioManager.Instance.OffSound();
                    SetSoundSprite();
                }
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

    private void SetMusicSprite()
    {
        if (PlayerPrefs.GetFloat("MusicVolume") == 0)
        {
            musicButton.GetComponent<Image>().sprite = musicOffSprite;
        }
        else
        {
            musicButton.GetComponent<Image>().sprite = musicOnSprite;
        }
    }

    private void SetSoundSprite()
    {
        if (PlayerPrefs.GetFloat("SoundVolume") == 0)
        {
            soundButton.GetComponent<Image>().sprite = soundOffSprite;
        }
        else
        {
            soundButton.GetComponent<Image>().sprite = soundOnSprite;
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
        scoreText.text = "High score: " + data.highScore;
    }
}
