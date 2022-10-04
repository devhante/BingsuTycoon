using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BingsuTycoon.Common
{
    public class BackgroudMusic : MonoBehaviour
    {
        private AudioSource audioComponent;
        private float originVolume;

        private void Awake()
        {
            audioComponent = GetComponent<AudioSource>();
            originVolume = audioComponent.volume;
        }

        private void Update()
        {
            if (SoundManager.Instance.BackgroundMusic == true)
            {
                audioComponent.volume = originVolume;
            }
            else
            {
                audioComponent.volume = 0f;
            }
        } 
    }
}