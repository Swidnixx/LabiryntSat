using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LabiryntGenerator))]
public class LabiryntGeneratorEditr : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Generate"))
        {
            (target as LabiryntGenerator).Generate();
        }
    }
}
