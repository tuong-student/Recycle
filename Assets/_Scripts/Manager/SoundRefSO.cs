using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.SO
{
    [CreateAssetMenu()]
    public class SoundRefSO : ScriptableObject
    {
        public AudioClip pause;
        public AudioClip buttonClick;
        public AudioClip hover;
        public AudioClip[] Correct;
        public AudioClip[] Wrong;
        public AudioClip[] PickUp;
        public AudioClip[] TimeAdded;
    }
}
