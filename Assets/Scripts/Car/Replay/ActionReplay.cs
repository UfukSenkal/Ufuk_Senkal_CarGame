using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarGame.Car.Replay
{
    public class ActionReplay : MonoBehaviour
    {

        #region Variables
        private List<Vector3> actionReplayRecordPos = new List<Vector3>();
        private List<Quaternion> actionReplayRecordRotations = new List<Quaternion>();
        private int currentReplayIndex;
        public int indexChangeRate;
        #endregion

        public CarManager.CarState thisCarState = CarManager.CarState.Waiting;

        private void Update()
        {

            switch (thisCarState)
            {
                case CarManager.CarState.MovingByRecord:
                    PlayRecord();
                    break;

                default:
                    break;
            }


        }

        /// <summary>
        /// Change transform of car to index at array
        /// </summary>
        /// <param name="index">index at position and rotation array</param>
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

        /// <summary>
        /// Move car with record
        /// </summary>
        public void PlayRecord()
        {

            int nextIndex = currentReplayIndex + indexChangeRate;

            if (nextIndex < actionReplayRecordPos.Count && nextIndex >= 0)
            {
                SetTransform(nextIndex);
            }
            if (nextIndex >= actionReplayRecordPos.Count)
            {

                thisCarState = CarManager.CarState.Parked;

            }
        }

        public void FirstPos(Transform firstTransform)
        {
            currentReplayIndex = 0;
            transform.position = firstTransform.position;
            transform.rotation = firstTransform.rotation;

            
        }

        internal void ClearRecordList()
        {
            actionReplayRecordPos.Clear();
            actionReplayRecordRotations.Clear();
        }
    }
}
