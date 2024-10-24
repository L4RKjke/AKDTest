using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFacing : MonoBehaviour
{
    private Camera _camera;
    private Camera _cachedCamera
    {
        get
        {
            if (_camera == null)
                _camera = Camera.main;
    				
            return _camera;
        }
    }
    
    private void Update ()
    {
        transform.rotation = Quaternion.LookRotation( transform.position - _cachedCamera.transform.position );
    }
}
