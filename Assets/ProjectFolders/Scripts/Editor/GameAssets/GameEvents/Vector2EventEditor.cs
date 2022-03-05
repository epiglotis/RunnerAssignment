using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Vector2Event), editorForChildClasses: true)]
public class Vector2EventEditor : GameEventEditor
{
    public Vector2 value;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        value = EditorGUILayout.Vector2Field("Value", value);
    }

    public override void ButtonClicked()
    {
        Vector2Event e = target as Vector2Event;
        e.Raise(value);
    }
}
