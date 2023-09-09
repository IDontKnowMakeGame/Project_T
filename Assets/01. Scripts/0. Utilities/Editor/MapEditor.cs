using Scripts.Utilities.Data;
using UnityEditor;
using UnityEngine;

namespace Scripts.Utilities.Editor
{
    [CustomEditor(typeof(MapData))]
    public class MapEditor : UnityEditor.Editor
    {
        MapData _mapData;

        private void OnEnable()
        {
            _mapData = (MapData) target;
        }
        
        public override void OnInspectorGUI()
        {
            _mapData.mapName = EditorGUILayout.TextField("Map Name", _mapData.mapName);
            _mapData.mapSize = EditorGUILayout.Vector2IntField("Map Size", _mapData.mapSize);


            for (int h = 0; h < _mapData.mapSize.y; h++)
            {
                EditorGUILayout.BeginHorizontal();
                for (var w = 0; w < _mapData.mapSize.x; w++)
                {
                    GUILayout.Button("", GUILayout.Width(20), GUILayout.Height(20));
                }
                EditorGUILayout.EndHorizontal();
            }
            
            EditorUtility.SetDirty(_mapData);
        }
    }
}