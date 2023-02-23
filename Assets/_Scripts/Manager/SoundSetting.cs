using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NOOD;

namespace Game.Manager
{
    public class SoundSetting : MonoBehaviorInstance<Manager.SoundSetting>
    {
        [SerializeField] private AudioSource audioSource;

        private bool isSoundEnable = true, isMusicEnable = true;

        public void PressSoundButton()
        {
            isSoundEnable = !isSoundEnable;
        }

        public void PressMusicButton()
        {
            isMusicEnable = !isMusicEnable;
            if(isMusicEnable)
            {
                audioSource.Play();
            }
            else
            {
                audioSource.Stop();
            }
        }

        public bool IsSoundEnable()
        {
            return isSoundEnable;
        }

        public bool IsMusicEnable()
        {
            return isMusicEnable;
        }
    }
}
