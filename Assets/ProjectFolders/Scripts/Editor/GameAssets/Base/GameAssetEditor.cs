using UnityEditor;

[CustomEditor(typeof(GameAsset), editorForChildClasses: true)]
public class GameAssetEditor : Editor
{
    private bool ShowAssetDescription
    {
        get => showAssetDescription;
        set
        {
            if(showAssetDescription == value) return;
            showAssetDescription = value;
            assetDescriptionClicked = true;
        }
    }
    private bool showAssetDescription;

    protected bool assetDescriptionClicked;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        assetDescriptionClicked = false;
        GameAsset gameAsset = target as GameAsset;
        ShowAssetDescription = EditorGUILayout.Foldout(ShowAssetDescription, "Asset Description",true);
        if (ShowAssetDescription)
        {
            EditorStyles.textField.wordWrap = true;
            EditorStyles.textField.fixedHeight = 150f;
            gameAsset.eventInfo = EditorGUILayout.TextArea(gameAsset.eventInfo);
        }
        EditorStyles.textField.fixedHeight = 20f;
    }
}
