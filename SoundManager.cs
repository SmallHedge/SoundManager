//Author: Small Hedge Games
//Updated: 16/05/2024

using UnityEngine;
using System;

namespace SHG.SoundManager
{
    public enum SoundType
    {
        //ADD SOUND EFFECT NAMES
    }

    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private SoundList[] soundList;
        private static SoundManager instance;
        private AudioSource audioSource;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
                Destroy(gameObject);
        }

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public static void PlaySound(SoundType sound, float volume = 1)
        {
            AudioClip[] clips = instance.soundList[(int)sound].Sounds;
            AudioClip randomClip = clips[UnityEngine.Random.Range(0, clips.Length)];
            instance.audioSource.PlayOneShot(randomClip, volume);
        }

        public void Resize()
        {
            string[] names = Enum.GetNames(typeof(SoundType));
            Array.Resize(ref soundList, names.Length);
            for (int i = 0; i < soundList.Length; i++)
                soundList[i].name = names[i];
        }
    }

    [Serializable]
    public struct SoundList
    {
        public AudioClip[] Sounds { get => sounds; }
        [HideInInspector] public string name;
        [SerializeField] private AudioClip[] sounds;
    }
}
