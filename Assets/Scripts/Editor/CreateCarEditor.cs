using CarGame.Car;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreateCarEditor : Editor
{
    [MenuItem("Car Game/Setup Scene")]
    static void SetupScene()
    {
      
        GameObject managers = Resources.Load<GameObject>("Prefabs/ManagerPoolBase");
        if (FindObjectOfType<ManagerPoolBase>() == null)
        {
            Instantiate(managers);
           
        }

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

    [MenuItem("Car Game/Create Car")]
    static void CreateCar()
    {
        
        GameObject carPackage = Resources.Load<GameObject>("Prefabs/CarBase");

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

    [MenuItem("Car Game/Create Obstacle")]
    static void CreateObstacle()
    {
       
        GameObject carPackage = Resources.Load<GameObject>("Prefabs/Obstacle");

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
