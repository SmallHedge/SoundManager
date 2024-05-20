//Author: Small Hedge Games
//Updated: 20/05/2024

using UnityEngine;
using System;
using System.Collections.Generic;

namespace SHG.SoundManager
{
    public enum SoundType
    {
        TEST,
        UI_HOVER,
        UI_CLICK,
        UI_GAMESTART,
        UI_OPTIONS,
        UI_QUIT,
    }

    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private SoundList[] soundList;
        private static SoundManager instance;
        private AudioSource audioSource;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public static void PlaySound(SoundType sound, float volume = 1)
        {
            AudioClip[] clips = instance.soundList[(int)sound].sounds;
            AudioClip randomClip = clips[UnityEngine.Random.Range(0, clips.Length)];
            instance.audioSource.PlayOneShot(randomClip, volume);
        }

        public void Resize()
        {
            Dictionary<string, AudioClip[]> clips = new();
            for (int i = 0; i < soundList.Length; ++i)
            {
                if (soundList[i].sounds.Length > 0)
                    clips.Add(soundList[i].name, soundList[i].sounds);
            }

            string[] names = Enum.GetNames(typeof(SoundType));
            Array.Resize(ref soundList, names.Length);
            for (int i = 0; i < soundList.Length; i++)
            {
                string currentName = names[i];
                soundList[i].name = currentName;
                if (clips.ContainsKey(currentName))
                    soundList[i].sounds = clips[currentName];
                else
                    soundList[i].sounds = null;
            }
        }
    }

    [Serializable]
    public struct SoundList
    {
        [HideInInspector] public string name;
        public AudioClip[] sounds;
    }
}
