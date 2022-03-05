using UnityEditor;

[CustomEditor(typeof(FloatEvent), editorForChildClasses: true)]
public class FloatEventEditor : GameEventEditor
{
    public float value;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        value = EditorGUILayout.FloatField("Value", value);
    }

    public override void ButtonClicked()
    {
        FloatEvent e = target as FloatEvent;
        e.Raise(value);
    }
}
