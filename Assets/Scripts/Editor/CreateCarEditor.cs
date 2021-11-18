using CarGame.Car;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreateCarEditor : Editor
{

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
        GameObject obstacles = FindObjectOfType<ObstacleParentBase>().gameObject;
        GameObject carPackage = Resources.Load<GameObject>("Prefabs/Obstacle");

        if (obstacles == null)
        {
            Debug.LogError("Need to Setup Scene  --- Obstacle GameObject is Missing");
        }
        else
        {
            Instantiate(carPackage, obstacles.transform);
        }

        

    }
}
