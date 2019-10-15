using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CostumePropertyDrawer : PropertyDrawer
{
    bool showStats = true;
    //public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    //{
        /*SerializedProperty strength = property.FindPropertyRelative("strength");
        SerializedProperty baseSpeed = property.FindPropertyRelative("baseSpeed");
        SerializedProperty sprintMultiplier = property.FindPropertyRelative("sprintMultiplier");
        SerializedProperty jumpForce = property.FindPropertyRelative("jumpForce");
        SerializedProperty flight = property.FindPropertyRelative("flight");

        EditorGUI.BeginProperty(position, label, property);

        label.text = "Costume Stats";

        showStats = EditorGUI.Foldout(position, showStats, label);

        if (showStats)
        {
            EditorGUILayout.PropertyField(strength);
            EditorGUILayout.PropertyField(baseSpeed);
            EditorGUILayout.PropertyField(sprintMultiplier);
            EditorGUILayout.LabelField(
                "Sprint Speed: " + baseSpeed.floatValue + " * " + sprintMultiplier.floatValue + " = " + baseSpeed.floatValue * sprintMultiplier.floatValue
                );
            EditorGUILayout.PropertyField(jumpForce);
            EditorGUILayout.PropertyField(flight);
        }
        
        EditorGUI.EndProperty();

        SerializedProperty it = strength.Copy();

        while (it.Next(false))
            Debug.Log(it.name);*/
    //}
}