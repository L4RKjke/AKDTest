using Game.Scripts.Entities;
using UniRx;
using UnityEngine;

namespace Game.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Player _player;
        [SerializeField] InputHandler _inputHandler;
        [SerializeField] ObjSelector objSelector;
        
        public void Start()
        {
            _inputHandler.OnInteractiveClick
                .Subscribe( _ => OnActionClick() )
                .AddTo(this);
        }

        void OnActionClick()
        {
            if (objSelector.Selected == null)
                return;

            var obj = objSelector.Selected;
                
            if ( obj.TryGetComponent( out Item item )  )
                _player.Take( item  );
            else if ( obj.TryGetComponent( out Car car ) )
                _player.Put( car );
        }
    }
}