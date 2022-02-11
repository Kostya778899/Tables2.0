using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UiButton : MonoBehaviour
{
    // Variables


    private void Start()
    {
        
    }


#if UNITY_EDITOR
    [CustomEditor(typeof(UiButton)), CanEditMultipleObjects]
    private class UiButtonEditor : Editor
    {
        UiButton _target;

        private void OnEnable() => _target = (UiButton)target;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

        }
    }
#endif
}
