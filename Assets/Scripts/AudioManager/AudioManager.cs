using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume = PlayerPrefs.GetFloat("Volume");
            s.source.pitch = s.pitch = 1;
            s.source.loop = s.loop;

            if (s.name == "Music")
            {
                s.source.volume = s.volume = PlayerPrefs.GetFloat("MusicVolume");
            }
        }
    }

    private void Start()
    {
        Play("Music");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }
        s.source.Play();
    }
}
