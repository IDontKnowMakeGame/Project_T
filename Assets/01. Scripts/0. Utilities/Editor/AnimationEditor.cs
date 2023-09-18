using Scripts.Utilities.Data;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

namespace Scripts.Utilities.Editor
{
    [CustomEditor(typeof(AnimationData))]
    public class AnimationEditor : UnityEditor.Editor
    {
        private AnimationData _aniData;
        private float _time = 0f;
        private int _currentFrame = 0;
        private void OnEnable()
        {
            _aniData = (AnimationData)target;
        }

        public override void OnInspectorGUI()
        {
            _aniData.texture = (Texture)EditorGUILayout.ObjectField("Texture", _aniData.texture, typeof(Texture), false);
            _aniData.material = (Material)EditorGUILayout.ObjectField("Material", _aniData.material, typeof(Material), false);
            _aniData.columns = EditorGUILayout.IntField("Columns", _aniData.columns);
            _aniData.rows = EditorGUILayout.IntField("Rows", _aniData.rows);
            _aniData.totalFrames = EditorGUILayout.IntField("Total Frames", _aniData.totalFrames);
            _aniData.moveSecond = EditorGUILayout.FloatField("Move Second", _aniData.moveSecond);
            _aniData.loop = EditorGUILayout.Toggle("Loop", _aniData.loop);

            if(!_aniData.loop)
            {
                _aniData.nextIdx = EditorGUILayout.IntField("Next Idx", _aniData.nextIdx);
            }

            if (Application.isPlaying == false)
            {
                if (_aniData.texture)
                {
                    var rect = EditorGUILayout.GetControlRect();
                    var width =  (float) _aniData.texture.width / _aniData.columns;
                    var height = (float) _aniData.texture.height / _aniData.rows;
                    var offset = 1 / (float) _aniData.columns;
                
                    rect.width = width;
                    rect.height = height;
                    //rect.height = _aniData.texture.height * (rect.width / _aniData.texture.width);
                    _aniData.material.SetVector("_Tiling", new Vector4(offset, 1));

                    _time += Time.deltaTime * 6;
                    if (_time > _aniData.moveSecond / _aniData.totalFrames)
                    {
                        _currentFrame++;
                        _time = 0f;
                    
                        if (_currentFrame >= _aniData.totalFrames)
                            _currentFrame = 0;
                    
                    
                        _aniData.material.SetVector("_Offset", new Vector4(_currentFrame * offset, 0));
                    }

                    if(_aniData.material)
                        EditorGUI.DrawPreviewTexture(rect, _aniData.texture, _aniData.material, ScaleMode.StretchToFill, 0, -1, ColorWriteMask.All, 0);
                }   
            }

            EditorUtility.SetDirty(_aniData);
        }
    }
}