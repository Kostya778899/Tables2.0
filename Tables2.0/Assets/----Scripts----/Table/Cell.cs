using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Cell : MonoBehaviour
{
    // Variables


    private void Start()
    {
        
    }


#if UNITY_EDITOR
    [CustomEditor(typeof(Cell)), CanEditMultipleObjects]
    private class CellEditor : Editor
    {
        Cell _target;

        private void OnEnable() => _target = (Cell)target;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

        }
    }
#endif
}
