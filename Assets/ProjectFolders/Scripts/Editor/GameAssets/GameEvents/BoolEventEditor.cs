using UnityEditor;

[CustomEditor(typeof(BoolEvent), editorForChildClasses: true)]
public class BoolEventEditor : GameEventEditor
{
    public bool value;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        value = EditorGUILayout.Toggle("Value", value);
    }

    public override void ButtonClicked()
    {
        BoolEvent e = target as BoolEvent;
        e.Raise(value);
    }
}
