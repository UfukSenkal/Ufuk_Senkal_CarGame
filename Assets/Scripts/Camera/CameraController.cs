using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //PORTRAIT ONLY CAMERA HANDLER

    private const float _width = 1080f;
    private const float _height = 1920f;
    private void Start()
    {
        Camera.main.aspect = _width / _height;
    }
}
