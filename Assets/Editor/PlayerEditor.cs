﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Player))]
public class PlayerEditor : Editor
{
    Player player;

    private void OnEnable()
    {
        player = (Player)target;
    }

    public override void OnInspectorGUI()
    {
        SerializedProperty currentCostume = serializedObject.FindProperty("currentCostume");

        serializedObject.Update();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("health"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("healthDisplay"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("attackBox"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("isAbleToFly"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("costumeColors"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("onGround"));
        EditorGUILayout.PropertyField(currentCostume);

        serializedObject.ApplyModifiedProperties();
    }
}
