using System;
using UnityEngine;

namespace DotRescue._Scripts
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        [SerializeField] private AudioSource _effectSource;

        public void PlaySound(AudioClip clip)
        {
            _effectSource.PlayOneShot(clip);
        }
    }
}