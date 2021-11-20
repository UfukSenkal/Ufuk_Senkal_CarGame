using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CarGame
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;
        private void Awake()
        {
            Instance = this;
        }


        public void NextLevel()
        {
            if ((SceneManager.GetActiveScene().buildIndex + 1) != SceneManager.sceneCountInBuildSettings)
            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                Debug.LogError("LEVELS COMPLETED!");
                Debug.LogWarning("If you have more levels to add, please add it to build settings.");
            }
        }

        public void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
