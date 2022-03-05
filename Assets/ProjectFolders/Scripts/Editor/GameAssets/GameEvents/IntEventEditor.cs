using UnityEditor;

[CustomEditor(typeof(IntEvent), editorForChildClasses: true)]
public class IntEventEditor : GameEventEditor
{
    public int value;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        value = EditorGUILayout.IntField("Value", value);
    }

    public override void ButtonClicked()
    {
        IntEvent e = target as IntEvent;
        e.Raise(value);
    }
}
