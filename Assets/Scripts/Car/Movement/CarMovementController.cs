using CarGame.Car.Replay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CarGame.InputSystem;
using System;

namespace CarGame.Car.Movement {
    public class CarMovementController : AbstractCarBase
    {
        #region Variables

        [SerializeField] private CarMovementSettings_SO _carSettings;
        [SerializeField] private ActionReplay _actionReplay;
        [SerializeField] private InputData _inputData;
        [SerializeField] private Transform _startPos;
        [SerializeField] private Collider _exitCollider;
        [SerializeField] private Rigidbody _carRigidbody;
        private bool _isFinishedMove = false;



        public override Transform FirstPos { get => _startPos;}
        public override Collider ExitCollider { get => _exitCollider; }
        public override Rigidbody CarRigidbody { get => _carRigidbody; }
        #endregion

        private void Update()
        {
            switch (GameManager.Instance.CurrentGameState)
            {
                case GameManager.GameState.WaitingInput:
                    ResetPos();
                    _isFinishedMove = false;
                    break;
                case GameManager.GameState.Started:
                    if (base.IsActive)
                    {
                        if (!IsCarInScreen())
                        {
                            GameManager.Instance.CurrentGameState = GameManager.GameState.WaitingInput;
                            CarManager.Instance.carState = CarManager.CarState.Waiting;
                            CarManager.Instance.SetAllFirstPos();

                            this.GetComponent<CarMovementController>().ResetRecord();
                        }

                        Rotate();
                        Move();
                        RecordPlay();

                    }
                    else
                    {
                        CheckRecordPlay();
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// If car move hasn't finished check for record
        /// </summary>
        private void CheckRecordPlay()
        {
            if (!_isFinishedMove)
            {
                
                _actionReplay.thisCarState = CarManager.CarState.MovingByRecord;
            }
        }

        public override void Move()
        {
            // rb move istedi?im gibi ?al??mad? burada
            //_carRigidbody.MovePosition( transform.position + (transform.forward * _carSettings.CarSpeed * Time.deltaTime));

            transform.Translate(transform.forward * _carSettings.CarSpeed, Space.World);
        }

        /// <summary>
        /// Record Car Movement
        /// </summary>
        public override void RecordPlay()
        {

            _actionReplay.Record();
        }


        public override void Rotate()
        {
        
            transform.Rotate(0, _inputData.IsTouching * (_inputData.IsLeft ? -_carSettings.CarRotationSpeed : _carSettings.CarRotationSpeed), 0, Space.Self);
        }

        /// <summary>
        /// Take car to first pos
        /// </summary>
        public override void ResetPos()
        {
            _actionReplay.FirstPos(FirstPos);
        }
        public void Park()
        {
            _isFinishedMove = true;
            _actionReplay.thisCarState = CarManager.CarState.Parked;
        }

        public override void ResetRecord()
        {
            _actionReplay.ClearRecordList();
        }

        public bool IsCarInScreen()
        {
            Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            Vector3 viewPos = transform.position;
            if ((viewPos.x < screenBounds.x  && viewPos.x > -screenBounds.x) && (viewPos.z < screenBounds.y/2 && viewPos.z > -screenBounds.y/2))
            {
                return true;
            }
            return false;
        }

    }
}
