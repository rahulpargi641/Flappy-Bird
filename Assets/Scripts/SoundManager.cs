using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    public SoundTypes[] m_SoundTypes;

    public AudioSource m_AudioSource;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(ESounds sound)
    {
        AudioClip audioClip = GetSoundClip(sound);
        if (audioClip != null)
        {
            m_AudioSource.PlayOneShot(audioClip);
        }
        else
        {
            Debug.LogError("Audio Clip not found for sound types" + sound);
        }
    }
    private AudioClip GetSoundClip(ESounds sound)
    {
        SoundTypes soundType = Array.Find(m_SoundTypes, soundType => soundType.ES_Sound == sound);
        if (soundType != null)
            return soundType.m_AudioClip;
        else
            return null;
    }
    public enum ESounds
    {
        ButtonClick, BirdJump, Score, BirdCollided
    }

    [Serializable]
    public class SoundTypes
    {
        public ESounds ES_Sound;
        public AudioClip m_AudioClip;
    }
}
