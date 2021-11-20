using CarGame.Car;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace CarGame.Level
{

    [CustomEditor(typeof(LevelSettings_SO))]
    public class SceneEditor : Editor
    {


        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            LevelSettings_SO example = (LevelSettings_SO)target;

            if (GUILayout.Button("Create scene"))
            {
                CreateScene(example.LevelCount);
                SetupScene();
                //CreateCar(example.CarCount);
                //CreateObstacle(example.ObstacleCount);
            }
            if (GUILayout.Button("Setup Scene"))
            {
                SetupScene();
            }
            if (GUILayout.Button("Create Car"))
            {
                CreateCar(example.CarCount);
            }
            if (GUILayout.Button("Create Obstacle"))
            {
                CreateObstacle(example.ObstacleCount);
            }
        }



        static void SetupScene()
        {

            GameObject camera = Resources.Load<GameObject>("Prefabs/MainCamera");
            if (FindObjectOfType<Camera>() == null)
            {
                Instantiate(camera);
            }
            else
            {
                Camera mainCam = FindObjectOfType<Camera>();
                mainCam.orthographic = true;
                mainCam.transform.position = camera.transform.position;
                mainCam.transform.rotation = camera.transform.rotation;
            }
            GameObject light = Resources.Load<GameObject>("Prefabs/Directional Light");
            if (FindObjectOfType<Light>() == null)
            {
                Instantiate(light);
            }
            else
            {
                Light mainLight = FindObjectOfType<Light>();
                mainLight.type = LightType.Directional;
                mainLight.shadows = LightShadows.None;
            }
            GameObject managers = Resources.Load<GameObject>("Prefabs/ManagerPoolBase");
            if (FindObjectOfType<ManagerPoolBase>() == null)
            {
                Instantiate(managers);

            }

            GameObject canvas = Resources.Load<GameObject>("Prefabs/Canvas");
            if (FindObjectOfType<CanvasBase>() == null)
            {
                Instantiate(canvas);

            }


            GameObject carBase = Resources.Load<GameObject>("Prefabs/CarPoolBase");
            if (FindObjectOfType<CarParentBase>() == null)
            {
                Instantiate(carBase);
            }

            GameObject obstacleBase = Resources.Load<GameObject>("Prefabs/ObstaclePoolBase");
            if (FindObjectOfType<ObstacleParentBase>() == null)
            {
                Instantiate(obstacleBase);
            }
        }


        static void CreateCar(int carCount)
        {

            GameObject carPackage = Resources.Load<GameObject>("Prefabs/CarBase");

            for (int i = 0; i < carCount; i++)
            {

                if (FindObjectOfType<CarParentBase>() == null)
                {
                    Debug.LogError("Need to Setup Scene  --- Cars GameObject is Missing");
                }
                else
                {
                    GameObject cars = FindObjectOfType<CarParentBase>().gameObject;
                    Instantiate(carPackage, cars.transform);
                }
            }




        }


        static void CreateObstacle(int obstacleCount)
        {

            GameObject carPackage = Resources.Load<GameObject>("Prefabs/Obstacle");

            for (int i = 0; i < obstacleCount; i++)
            {

                if (FindObjectOfType<ObstacleParentBase>() == null)
                {
                    Debug.LogError("Need to Setup Scene  --- Obstacle GameObject is Missing");
                }
                else
                {
                    GameObject obstacles = FindObjectOfType<ObstacleParentBase>().gameObject;
                    Instantiate(carPackage, obstacles.transform);
                }
            }


        }

        static void CreateScene(int levelCount)
        {

            Scene newScene = EditorSceneManager.NewScene(0);
            newScene.name = "Level" + levelCount;

        }
    }
}
