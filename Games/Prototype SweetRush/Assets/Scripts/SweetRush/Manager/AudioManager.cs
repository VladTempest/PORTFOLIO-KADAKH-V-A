

using System;
using System.Collections.Generic;
using UnityEngine.Audio;

namespace SweetRush
{
    using UnityEngine;
    using Random = UnityEngine.Random;
[System.Serializable]
    public class SoundTrack
    {
        public string name="audiotrack";
        public AudioClip clip;
        [Range(0f, 1f)]
        public float volume;
        public int numberOfAudioSource=0;
    }
    public class AudioManager : SingletonInitiatorBase<AudioManager>
    {
        [SerializeField]
        private PoolSoundsMainSettings _poolMain = null;
        [SerializeField]
        private PoolSoundsEatingSettings _poolEating = null;
        [SerializeField]
        private PoolSoundsWooshSettings _poolWoosh = null;
        [SerializeField]
        private PoolSoundsPopSettings _poolPop = null;
        [SerializeField]
        private PoolSoundsObstacleKillSettings _poolObstacleKill = null;
        [SerializeField]
        private PoolSoundsAnimalScreamSettings _poolAnimalScream = null;
        [SerializeField]
        private PoolSoundsWindowsScrrSettings _poolWindowsScrr = null;
        [SerializeField]
        private GameObject _musicChild=null;
        [SerializeField]
        private GameObject _sfxChild=null;
        [SerializeField]
        private AudioMixer _audioMixer = null;

        private AudioSource _musicAudioSource=null;
        private List<PoolSoundsOfPoolsSettings> _poolGeneral = null;
        private List<AudioSource> _sfxAudioSources =new List<AudioSource>();


        private void Awake()
        {
           _musicAudioSource = _musicChild.GetComponent<AudioSource>();
            
            _poolGeneral = new List<PoolSoundsOfPoolsSettings>()
                { _poolEating, _poolWoosh, _poolPop,_poolMain, _poolObstacleKill,_poolAnimalScream,_poolWindowsScrr};
            for (int i = 0; i < 12; i++)
            {
                _sfxAudioSources.Add(_sfxChild.AddComponent<AudioSource>());
                _sfxAudioSources[i].outputAudioMixerGroup = _audioMixer.FindMatchingGroups("SFX")[0];
                
            }

            
            {
                _sfxAudioSources.Add(_musicChild.AddComponent<AudioSource>());
                _sfxAudioSources[12].outputAudioMixerGroup = _audioMixer.FindMatchingGroups("OST")[0];
                _sfxAudioSources[12].loop=true;
            }
        }


        public void PlaySoundFX(int numberOfPool, int numberOfSfx = 0)
        {
            var currentPool = GetThePool(numberOfPool);
            
            if ((numberOfPool<3)||numberOfPool>5)
            {
                numberOfSfx = Random.Range(0, currentPool.Count);
            }
            
            _sfxAudioSources[currentPool[numberOfSfx].numberOfAudioSource].PlayOneShot(currentPool[numberOfSfx].clip,currentPool[numberOfSfx].volume);
        }

        public void PlayOrStopOST(bool toPlay, int numberOfPool=3, int numberOfSfx = 0)
        {
            var currentPool = GetThePool(numberOfPool);
            
            _sfxAudioSources[currentPool[numberOfSfx].numberOfAudioSource].clip=currentPool[numberOfSfx].clip;
            _sfxAudioSources[currentPool[numberOfSfx].numberOfAudioSource].volume=currentPool[numberOfSfx].volume;
            if (toPlay)
            {
                _sfxAudioSources[currentPool[numberOfSfx].numberOfAudioSource].Play();
            }
            else _sfxAudioSources[currentPool[numberOfSfx].numberOfAudioSource].Stop();
        

            
        }

        public void ChooseSoundtrackByDifficulty(GameDifficulty difficulty)
        {
            switch (difficulty)
            {
                case GameDifficulty.Easy:
                    PlayOrStopOST(false);
                    PlayOrStopOST(true, 3,0);
                    break;
                case GameDifficulty.Medium:
                    PlayOrStopOST(false);
                    PlayOrStopOST(true, 3, 1);
                    break;
                case GameDifficulty.Hard:
                    PlayOrStopOST(false);
                    PlayOrStopOST(true, 3, 10);
                    break;

            }
        }

        public List<SoundTrack> GetThePool(int numberOfPool) 
        {
            switch (numberOfPool)
            {
                
                case 0:
                    return _poolEating.pool;
                case 1:
                    return _poolWoosh.pool;
                case 2:
                 return _poolPop.pool;
                case 3:
                    return _poolMain.pool;
                case 4:
                    return _poolObstacleKill.pool;
                case 5:
                    return _poolAnimalScream.pool;
                case 6:
                    return _poolWindowsScrr.pool;
                default:
                    return _poolMain.pool;
            }

        }
    }

}
   

