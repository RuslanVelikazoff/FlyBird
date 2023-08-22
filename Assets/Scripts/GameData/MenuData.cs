using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuData : MonoBehaviour
{
    public int highScore;

    public bool easyLevel;
    public bool midleLevel;
    public bool hardLevel;

    private const string saveKey = "mainSave";

    public void Initialize()
    {
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

        highScore = data.highScore;
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
            highScore = highScore,
            EasyLevel = easyLevel,
            MidleLevel = midleLevel,
            HardLevel = hardLevel
        };

        return data;
    }
}
