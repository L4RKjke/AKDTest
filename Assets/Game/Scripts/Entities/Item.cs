using Game.Scripts.Entities;
using UnityEngine;

namespace Game.Scripts
{
    public class Item : MonoBehaviour, ISelectable
    {
        [SerializeField] ItemGlow _itemGlow;
        
        public void Select(bool select)
        {
            _itemGlow.TweenGlowing( select );
        }
    }
}