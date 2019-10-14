using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CostumeManager))]
public class CostumeManagerEditor : Editor
{
    CostumeManager _this;
    SerializedProperty costumeScripts;

    private void OnEnable()
    {
        _this = (CostumeManager)target;
        costumeScripts = serializedObject.FindProperty("costumeScripts");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        GUILayout.BeginVertical();
        for (int i = 0; i < costumeScripts.arraySize; i++)
        {
            Costume current = (Costume)i;
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(current.ToString());
            EditorGUILayout.PropertyField(costumeScripts.GetArrayElementAtIndex(i), GUIContent.none);
            if (GUILayout.Button("Remove"))
            {
                costumeScripts.DeleteArrayElementAtIndex(i);
            }
            GUILayout.EndHorizontal();
        }
        GUILayout.EndVertical();

        if (GUILayout.Button("Add Costume"))
        {
            if (costumeScripts.arraySize >= CostumeManager.numCostumes)
            {
                Debug.LogError("Adding more costumes than currently available");
            }
            else
                costumeScripts.InsertArrayElementAtIndex(costumeScripts.arraySize);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
