using System;
using UnityEngine;
using System.Collections;

namespace Game.Scripts
{
    public class GarageDoorOpener : MonoBehaviour
    {
        [SerializeField] Transform _door;
        [SerializeField] float _speed;
        
        void Start()
        {
            StartCoroutine(nameof(OpenRoutine));
        }

        IEnumerator OpenRoutine()
        {
            var ls = _door.localScale;
            float yScale = ls.y;
            
            while (yScale > 0.01f)
            {
                yScale = Mathf.Max( yScale - _speed, 0 );
               
                _door.localScale = new Vector3(ls.x, yScale, ls.z);
                
                yield return null;   
            }
        }
    }
}