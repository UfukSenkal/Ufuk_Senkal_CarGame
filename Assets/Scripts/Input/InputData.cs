using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarGame.InputSystem
{
    [CreateAssetMenu(menuName = "CarGame/Input/Input Data")]
    public class InputData : ScriptableObject
    {
        private bool _isLeft;
        private float _isTouching;

        public bool IsLeft { get { return _isLeft; } }
        public float IsTouching { get { return _isTouching; } }

       public void ProccessInput()
        {


#if UNITY_EDITOR

            if (Input.GetMouseButton(0))
            {
               
                if (Input.mousePosition.x <= Screen.width / 2)
                {
                    _isLeft = true;
                    
                }
                else
                {
                    _isLeft = false;
                    
                }
               
            }


#else


            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                if (touch.position.x <= Screen.width / 2)
                {
                    Debug.Log("Left click");
                }
                else
                {
                    Debug.Log("Right click");
                }
                //_isTouching = true;
            }
          
#endif
            _isTouching = Mathf.Clamp(Input.GetAxis("Fire1"),-1,1);

        }

        public void ResetInput()
        {
            _isTouching = 0;
        }
    }
}
