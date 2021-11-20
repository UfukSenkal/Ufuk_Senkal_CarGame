using CarGame.Car;
using CarGame.Car.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarGame
{
    public class CarManager : MonoBehaviour
    {
        public static CarManager Instance;

        public enum CarState
        {
            Waiting,
            Moving,
            MovingByRecord,
            Parked
        }
        public CarState carState = CarState.Waiting;

        #region Variables
        private Transform _carParent;
        private List<CarMovementController> carList = new List<CarMovementController>();
        [SerializeField] private CarSettings_SO _carSettings;
        #endregion

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _carParent = FindObjectOfType<CarParentBase>().transform;

            for (int i = 0; i < _carParent.childCount; i++)
            {
                carList.Add(_carParent.GetChild(i).GetChild(0).GetComponent<CarMovementController>());
                carList[i].transform.position = carList[i].FirstPos.position;
                carList[i].transform.rotation = carList[i].FirstPos.rotation;
                carList[i].transform.parent.gameObject.SetActive(false);
            }

        }

        public CarMovementController GetActiveCar()
        {
            CarMovementController activeCar = new CarMovementController();

            for (int i = 0; i < carList.Count; i++)
            {
                if (carList[i].isActive())
                {
                    activeCar = carList[i];
                    break;

                }
            }

            if (activeCar == null)
            {
                activeCar = carList[0];
                activeCar.IsActive = true;
            }
            activeCar.transform.parent.gameObject.SetActive(true);
            ChangeActiveCarColor(activeCar);
            return activeCar;
        }

        public void ChangeActiveCar()
        {
            CarMovementController activeCar = new CarMovementController();

            for (int i = 0; i < carList.Count - 1; i++)
            {
                if (carList[i].isActive())
                {
                    carList[i].IsActive = false;
                    carList[i].transform.parent.transform.GetChild(2).gameObject.SetActive(false);
                    carList[i].transform.parent.transform.GetChild(1).gameObject.SetActive(false);
                    ChangeReplayCarColor(carList[i]);
                    activeCar = carList[i + 1];
                    activeCar.IsActive = true;
                    
                    break;

                }
            }
            
            
            SetAllFirstPos();


        }

        public void SetAllFirstPos()
        {
            for (int i = 0; i < carList.Count - 1; i++)
            {
                carList[i].ResetPos();
            }
        }

        private void ChangeActiveCarColor(CarMovementController activeCar)
        {
            activeCar.GetComponent<MeshRenderer>().material = _carSettings.PlayerMaterial;
        }
        private void ChangeReplayCarColor(CarMovementController replayCar)
        {
            replayCar.GetComponent<MeshRenderer>().material = _carSettings.ReplayMaterial;
        }

        public bool CheckLastCar(CarMovementController activeCar)
        {
            if (activeCar == carList[carList.Count - 1])
            {
                return true;
            }
            return false;
        }
    }
}
