using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CarGame.Car.AbstractCarBase;

namespace CarGame.Car.Replay
{
    public class ActionReplay : MonoBehaviour
    {

      


        private bool isInReplayMode;
        [SerializeField] Rigidbody _rigidbody;
        private List<Vector3> actionReplayRecordPos = new List<Vector3>();
        private List<Quaternion> actionReplayRecordRotations = new List<Quaternion>();
        private int currentReplayIndex;
        private Vector3 _lastPos = Vector3.zero;
        public int indexChangeRate;
        private bool _isrecording = false;

        public CarManager.CarState thisCarState = CarManager.CarState.Waiting;

        private void Update()
        {

            switch (thisCarState)
            {
                case CarManager.CarState.Waiting:
                    FirstPos();
                    break;
                case CarManager.CarState.Moving:
                    break;
                case CarManager.CarState.MovingByRecord:
                    PlayRecord();
                    break;
                case CarManager.CarState.Parked:
                    break;
                default:
                    break;
            }


        }

        private void SetTransform(int index)
        {
            currentReplayIndex = index;


            transform.position = actionReplayRecordPos[index];
            transform.rotation = actionReplayRecordRotations[index];
        }

        /// <summary>
        /// Record Movement of Car
        /// </summary>
        /// <param name="isRecording">True for record, False for stop</param>
        public void Record()
        {
            thisCarState = CarManager.CarState.Moving;
            actionReplayRecordPos.Add(transform.position);
            actionReplayRecordRotations.Add(transform.rotation);
        }

        public void PlayRecord()
        {
            thisCarState = CarManager.CarState.MovingByRecord;
            int nextIndex = currentReplayIndex + indexChangeRate;

            if (nextIndex < actionReplayRecordPos.Count && nextIndex >= 0)
            {
                SetTransform(nextIndex);
            }
            if (nextIndex >= actionReplayRecordPos.Count)
            {

                thisCarState = CarManager.CarState.Parked;
                currentReplayIndex = 0;
            }
        }

        public void FirstPos()
        {
            if (actionReplayRecordPos.Count > 0)
            {

                transform.position = actionReplayRecordPos[0];
                transform.rotation = actionReplayRecordRotations[0];
            }
        }

    }
}