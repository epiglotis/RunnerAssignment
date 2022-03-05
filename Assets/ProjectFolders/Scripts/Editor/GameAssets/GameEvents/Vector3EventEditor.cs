using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Vector3Event), editorForChildClasses: true)]
public class Vector3EventEditor : GameEventEditor
{
    public Vector3 value;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        value = EditorGUILayout.Vector3Field("Value", value);
    }

    public override void ButtonClicked()
    {
        Vector3Event e = target as Vector3Event;
        e.Raise(value);
    }
}
