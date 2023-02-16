using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public static class Loader
    {
        public enum Scene
        {
            GameScene,
            LoadingScene,
            MainMenu,
        }

        private static Scene targetScene;

        public static void LoadToScene(Scene scene)
        {
            targetScene = scene;

            SceneManager.LoadScene(Scene.LoadingScene.ToString());
        }

        public static void LoadSceneCallback()
        {
            SceneManager.LoadScene(targetScene.ToString());

            Time.timeScale = 1f;
        }
    }
}
