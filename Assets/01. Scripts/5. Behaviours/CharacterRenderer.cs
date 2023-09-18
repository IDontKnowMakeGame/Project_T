using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.Utilities.Data;
using UnityEngine;

namespace Scripts.Behaviours
{
    public class CharacterRenderer : Behaviour
    {
        [SerializeField] private List<AnimationData> animationDataList;
        [SerializeField] private BlinkInfo blinkInfo;
        private Renderer _renderer;
        
        private AnimationData _aniData;
        private int _currentFrame;
        private float _time;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();

            if (animationDataList.Count > 0)
            {
                ChangeAnimation(animationDataList[0]);
            }
        }

        private void Start()
        {
            Character.OnDamage += Blink;
        }

        private void Update()
        {
            UpdateAnimation();
        }

        private void UpdateAnimation()
        {
            if (!_aniData) return;
            
            var width =  (float) _aniData.texture.width / _aniData.columns;
            var height = (float) _aniData.texture.height / _aniData.rows;
            var offset = 1 / (float) _aniData.columns;
                
            _renderer.material.SetVector("_Tiling", new Vector4(offset, 1));

            _time += Time.deltaTime;
            if (_time > _aniData.moveSecond / _aniData.totalFrames)
            {
                _currentFrame++;
                _time = 0f;


                if (_currentFrame >= _aniData.totalFrames)
                {
                    if (_aniData.loop)
                        _currentFrame = 0;
                    else
                    {
                        ChangeAnimation(GetAnimationData(_aniData.nextIdx));
                        return;    
                    }
                }
                    
                _renderer.material.SetVector("_Offset", new Vector4(_currentFrame * offset, 0));
                    
            }
        }

        public void ChangeAnimation(AnimationData data)
        {

            _aniData = data;
            _renderer.material.mainTexture = _aniData.texture;
            _renderer.material.SetVector("_Tiling", new Vector4(0, 1));
            _renderer.material.SetVector("_Offset", new Vector4(0, 0));
            _currentFrame = 0;
            _time = 0f;

        }

        public AnimationData GetAnimationData(int idx)
        {
            return animationDataList[idx];
        }

        private void Blink(int none)
        {
            StartCoroutine(BlinkCoroutine());
        }

        private IEnumerator BlinkCoroutine()
        {
            var mat = _renderer.material;

            for (var i = 0; i < blinkInfo.blinkCount; i++)
            {
                mat.SetFloat("_Blink", 1f);
                yield return new WaitForSeconds(blinkInfo.blinkInterval);
                mat.SetFloat("_Blink", 0f);
            }
        }
    }
}