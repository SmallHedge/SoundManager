//Author: Small Hedge Games
//Updated: 16/05/2024


#if UNITY_EDITOR
using UnityEditor;

namespace SHG.SoundManager
{
    [CustomEditor(typeof(SoundManager))]
    public class SoundManagerEditor : Editor
    {
        private void OnEnable()
        {
            ((SoundManager)target).Resize();
        }
    }
}
#endif