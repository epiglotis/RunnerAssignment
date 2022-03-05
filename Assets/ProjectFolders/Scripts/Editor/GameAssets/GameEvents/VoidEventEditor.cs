using UnityEditor;

[CustomEditor(typeof(VoidEvent), editorForChildClasses: true)]
public class VoidEventEditor : GameEventEditor
{
    public override void ButtonClicked()
    {
        VoidEvent e = target as VoidEvent;
        e.Raise();
    }
}
