using UnityEngine;

public class StartData : MonoBehaviour
{
    private const string saveKey = "mainSave";

    public bool easyLevel;
    public bool midleLevel;
    public bool hardLevel;

    private ScoreManager scoreManager;

    public void Initialize()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

        Load();

        Debug.Log("Data initialized");
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            Save();
        }
    }

    private void OnDisable()
    {
        Save();
    }

    private void Load()
    {
        var data = SaveManager.Load<Data.GameData>(saveKey);

        scoreManager.highScore = data.highScore;

        easyLevel = data.EasyLevel;
        midleLevel = data.MidleLevel;
        hardLevel = data.HardLevel;
    }

    private void Save()
    {
        SaveManager.Save(saveKey, GetSaveSnapshot());
        PlayerPrefs.Save();
    }

    public Data.GameData GetSaveSnapshot()
    {
        var data = new Data.GameData()
        {
            highScore = scoreManager.highScore,

            EasyLevel = easyLevel,
            MidleLevel = midleLevel,
            HardLevel = hardLevel
        };

        return data;
    }
}
