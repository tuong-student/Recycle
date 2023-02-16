using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class LoadingCallback : MonoBehaviour
    {
        private bool isFirstFrame;

        private void Update()
        {
            if(Input.anyKeyDown)
            {
                isFirstFrame = true;

                Loader.LoadSceneCallback();
            }
        }
    }
}
