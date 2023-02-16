using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NOOD;

namespace Game
{
    public class ResetStaticData : AbstractMonoBehaviour
    {
        public static ResetStaticData Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public override void Dispose()
        {
            DisposeAll();
        }
    }
}
