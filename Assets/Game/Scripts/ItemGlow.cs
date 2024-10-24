using System;
using DG.Tweening;
using UnityEngine;

namespace Game.Scripts
{
    public class ItemGlow : MonoBehaviour
    {
        [SerializeField] Material _litMaterial;
         
         Material               _defaultMaterial;
         MeshRenderer           _renderer;
         MaterialPropertyBlock  _mpb;      
         Color                  _baseColor;
         Tween                  _lightTween;
         bool                   _started;

         Material LitMaterial => _litMaterial;

         void Start()
         {
             _renderer          = GetComponent<MeshRenderer>();
             _defaultMaterial   = _renderer.sharedMaterial;
             _mpb               = new MaterialPropertyBlock();
             
             _renderer.GetPropertyBlock( _mpb );
             _baseColor = _mpb.GetColor( EmissionName );
             _renderer.SetPropertyBlock( _mpb );
             
             _started = true;
         }
        
         void OnDisable() => StopGlowing();

         public void TweenGlowing( bool isActive )
         {
             if ( isActive )
                 StartGlowing();
             else
                 StopGlowing();
         }
     
         void StartGlowing()
         {
             if ( !_started || _defaultMaterial == null ) return;
             
             Material lit                   = LitMaterial;
             _renderer.sharedMaterial       = lit;
             
             if(_defaultMaterial.mainTexture != null)
                Texture                     = _defaultMaterial.mainTexture;
             
             _lightTween?.Rewind();
             _lightTween?.Kill();
             _lightTween			= DOVirtual
                 .Float( 0, 0.67f, 0.8f, v => EmissionColor = new Color( v,v,v/1.3f, 1 ) )
                 .SetEase( Ease.InOutSine)
                 .SetLoops( -1, LoopType.Yoyo );
         }
     
         void StopGlowing()
         {
             if ( !_started || _mpb == null )
                 return;
             
             _lightTween?.Kill();
             EmissionColor = _baseColor;
             
             if(_defaultMaterial.mainTexture != null)
                Texture                    = _defaultMaterial.mainTexture;
             
             _renderer.sharedMaterial   = _defaultMaterial;
         }
         
         Color EmissionColor
         {
             get => _mpb.GetColor( EmissionName );
             set {_mpb.SetColor( EmissionName, value ); _renderer.SetPropertyBlock( _mpb );}
         }
         
         private Texture Texture
         {
             get => _mpb.GetTexture( MainTexture );
             set {_mpb.SetTexture(MainTexture, value); _renderer.SetPropertyBlock( _mpb );}
         }

         static readonly int MainTexture    = Shader.PropertyToID( "_MainTex" );
         static readonly int EmissionName   = Shader.PropertyToID( "_EmissionColor" );
    }
}