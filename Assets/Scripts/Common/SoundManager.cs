using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BingsuTycoon.Common
{
    public class SoundManager : MonoBehaviour
    {
        private static SoundManager instance = null;

        public static SoundManager Instance
        {
            get
            {
                return instance;
            }
        }

        private void Awake()
        {
            if (instance)
            {
                Destroy(this.gameObject);
                return;
            }

            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }

        public bool BackgroundMusic { get; set; } = true;
        public bool SoundEffect { get; set; } = true;
    }
}