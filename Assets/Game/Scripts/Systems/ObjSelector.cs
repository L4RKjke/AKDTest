using System;
using System.Linq;
using Game.Scripts.Entities;
using UnityEngine;

namespace Game.Scripts
{
    public class ObjSelector : MonoBehaviour
    {
        [SerializeField] float _maxDistance = 20;
        [SerializeField] LayerMask _layerMask;
        
        Camera _camera;
        
        public ObjFacade Selected { get; private set; }

        void Start()
        {
            _camera = Camera.main;;
        }

        void Update()
        {
            if (CheckCollisions( out ObjFacade item ))
            {
                if (Selected == item)
                    return;
                
                TryDeselect();
                Select( item );
            }
            else
            {
                TryDeselect();
            }
        }
        
        bool CheckCollisions<T>( out T obj ) where T: Component
        {
            Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));
            
            if (Physics.Raycast(ray, out RaycastHit hit, _maxDistance, _layerMask))
            {
                if (hit.transform.TryGetComponent( out T o ))
                {
                    obj = o;
                    return true;
                }
            }
            
            obj = null;
            return false;
        }

        void Select( ObjFacade selectable )
        {
            Selected = selectable;

            if (Selected.TryGetComponent(out ISelectable obj))
                obj.Select( true );
        }

        void TryDeselect()
        {
            if (Selected != null)
            {
                if (Selected.TryGetComponent(out ISelectable obj))
                    obj.Select( false );
                
                Selected = null;
            }
        }
    }
}