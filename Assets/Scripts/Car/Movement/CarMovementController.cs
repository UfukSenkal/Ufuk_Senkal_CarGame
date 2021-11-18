using CarGame.Car.Replay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CarGame.InputSystem;
using System;

namespace CarGame.Car.Movement {
    public class CarMovementController : AbstractCarBase
    {
        [SerializeField] private CarMovementSettings_SO _carSettings;
        [SerializeField] private ActionReplay _actionReplay;
        [SerializeField] private InputData _inputData;

        

        private void Update()
        {
            switch (GameManager.Instance.CurrentGameState)
            {
                case GameManager.GameState.WaitingInput:
                    break;
                case GameManager.GameState.Started:
                    if (base.isActive())
                    {
                        Rotate();
                        Move();
                        RecordPlay();

                    }
                    else
                    {
                        CheckRecordPlay();
                    }
                    break;
                case GameManager.GameState.GameOver:
                    break;
                default:
                    break;
            }

           

        }

        private void CheckRecordPlay()
        {
            _actionReplay.thisCarState = CarManager.CarState.MovingByRecord;
        }

        public override void Move()
        {
           
            transform.Translate(transform.forward * _carSettings.CarSpeed, Space.World);
        }

        public override void RecordPlay()
        {

            _actionReplay.Record();
        }

        public override void PlayMovement()
        {
            _actionReplay.PlayRecord();
        }

        public override void Rotate()
        {
            transform.Rotate(0, _inputData.IsTouching * (_inputData.IsLeft ? -_carSettings.CarRotationSpeed : _carSettings.CarRotationSpeed), 0, Space.Self);
        }

        public override void ResetPos()
        {
            _actionReplay.FirstPos();
        }
        public void Park()
        {
            _actionReplay.thisCarState = CarManager.CarState.Parked;
        }
    }
}
