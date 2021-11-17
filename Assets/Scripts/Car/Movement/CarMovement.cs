using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarGame.Car.Movement {
    public class CarMovement : AbstractCarBase
    {
        [SerializeField] private CarMovementSettings_SO _carSettings;

        private void Update()
        {
            

            if (base.isActive())
            {

                Move();
            }
        }

        public override void Move()
        {
            transform.Translate(transform.forward * _carSettings.CarSpeed, Space.World);
        }

        public override void RecordPlay()
        {
            
            throw new System.NotImplementedException();
        }

        public override void PlayMovement()
        {
            throw new System.NotImplementedException();
        }
    }
}
