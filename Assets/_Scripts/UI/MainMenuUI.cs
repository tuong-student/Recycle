using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button playBtn;
        [SerializeField] private Button exitBtn;

        private void Awake()
        {
            playBtn.onClick.AddListener(() =>
            {
                Loader.LoadToScene(Loader.Scene.GameScene);
            });
            exitBtn.onClick.AddListener(() =>
            {
                Application.Quit();
            });
        }
    }
}
