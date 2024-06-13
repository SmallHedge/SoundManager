SoundManager

Setup:
1. Open SoundValues.cs
2. Put in your sound names in the SoundType enum
3. Right click the Project tab and click Create->Small Hedge -> Sounds SO
4. Drag in your sounds and audio mixers (also the global volume slider!)
5. Call SoundManager.Play(SoundType sound, AudioSource source float volume) to play a random specified sound from anywhere!

Notes:
* Not passing through an Audio Source will use the SoundManagers default Audio Source

Tutorial: https://youtu.be/g5WT91Sn3hg
