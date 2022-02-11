using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TableDatas : MonoBehaviour
{
    // Variables


    private void Start()
    {
        
    }


#if UNITY_EDITOR
    [CustomEditor(typeof(TableDatas)), CanEditMultipleObjects]
    private class TableDatasEditor : Editor
    {
        TableDatas _target;

        private void OnEnable() => _target = (TableDatas)target;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

        }
    }
#endif
}
