//Author: Small Hedge Games
//Updated: 13/06/2024

#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

namespace SmallHedge.SoundManager
{
    [CustomEditor(typeof(SoundsSO))]
    public class SoundsSOEditor : Editor
    {
        private void OnEnable()
        {
            ref SoundList[] soundList = ref ((SoundsSO)target).sounds;

            if (soundList == null)
                return;

            string[] names = Enum.GetNames(typeof(SoundType));
            bool differentSize = names.Length != soundList.Length;

            Dictionary<string, SoundList> sounds = new();

            if (differentSize)
            {
                for (int i = 0; i < soundList.Length; ++i)
                {
                    sounds.Add(soundList[i].name, soundList[i]);
                }
            }

            Array.Resize(ref soundList, names.Length);
            for (int i = 0; i < soundList.Length; i++)
            {
                string currentName = names[i];
                soundList[i].name = currentName;
                if (soundList[i].volume == 0) soundList[i].volume = 1;

                if (differentSize)
                {
                    if (sounds.ContainsKey(currentName))
                    {
                        SoundList current = sounds[currentName];
                        UpdateElement(ref soundList[i], current.volume, current.sounds, current.mixer);
                    }
                    else
                        UpdateElement(ref soundList[i], 1, new AudioClip[0], null);

                    static void UpdateElement(ref SoundList element, float volume, AudioClip[] sounds, AudioMixerGroup mixer)
                    {
                        element.volume = volume;
                        element.sounds = sounds;
                        element.mixer = mixer;
                    }
                }
            }
        }
    }
}
#endif
