using UnityEngine;
using System;

///<Summary> Bu class oyun içerisinde eğer sadece bir event bir variableı set edecekse kullanılacaktır.
/// Bu classın olması şunu sağlamaktadır: variableı ve eventi gereksiz yere bir classa refere edip OnEnable ve OnDisable fonksiyonu 
/// çağırılması engellenmektedir. Bu scriptableObjectten oyunda sadece bir adet olacaktır.</Summary>
///<see cref="GameAsset"/>
[CreateAssetMenu(fileName = "NewVariableSetter", menuName = "GameAssets/VariableSetter")]
public class VariableSetter : GameAsset
{
    [SerializeField] private IntVariableSetter[] intVariableSetters;
    [SerializeField] private FloatVariableSetter[] floatVariableSetters;
    [SerializeField] private BoolVariableSetter[] boolVariableSetters;
    [SerializeField] private Vector2VariableSetter[] vector2VariableSetters;
    [SerializeField] private Vector3VariableSetter[] vector3VariableSetters;

    private void OnEnable() 
    {
        foreach(IntVariableSetter intVariableSetter in intVariableSetters)
            intVariableSetter.intEvent?.AddListener((value) => intVariableSetter.intVariable?.SetValue(value));

        foreach(FloatVariableSetter floatVariableSetter in floatVariableSetters)
            floatVariableSetter.floatEvent?.AddListener((value) => floatVariableSetter.floatVariable?.SetValue(value));

        foreach(BoolVariableSetter boolVariableSetter in boolVariableSetters)
            boolVariableSetter.boolEvent?.AddListener((value) => boolVariableSetter.boolVariable?.SetValue(value));

        foreach(Vector2VariableSetter vector2VariableSetter in vector2VariableSetters)
            vector2VariableSetter.vector2Event?.AddListener((value) => vector2VariableSetter.vector2Variable?.SetValue(value));
            
        foreach(Vector3VariableSetter vector3VariableSetter in vector3VariableSetters)
            vector3VariableSetter.vector3Event?.AddListener((value) => vector3VariableSetter.vector3Variable?.SetValue(value));
    }

    private void OnDisable() 
    {
        foreach(IntVariableSetter intVariableSetter in intVariableSetters)
            intVariableSetter.intEvent?.RemoveListener((value) => intVariableSetter.intVariable?.SetValue(value));

        foreach(FloatVariableSetter floatVariableSetter in floatVariableSetters)
            floatVariableSetter.floatEvent?.RemoveListener((value) => floatVariableSetter.floatVariable?.SetValue(value));

        foreach(BoolVariableSetter boolVariableSetter in boolVariableSetters)
            boolVariableSetter.boolEvent?.RemoveListener((value) => boolVariableSetter.boolVariable?.SetValue(value));

        foreach(Vector2VariableSetter vector2VariableSetter in vector2VariableSetters)
            vector2VariableSetter.vector2Event?.RemoveListener((value) => vector2VariableSetter.vector2Variable?.SetValue(value));

        foreach(Vector3VariableSetter vector3VariableSetter in vector3VariableSetters)
            vector3VariableSetter.vector3Event?.RemoveListener((value) => vector3VariableSetter.vector3Variable?.SetValue(value));
    }
}

[Serializable]
public struct IntVariableSetter
{
    public IntVariable intVariable;
    public IntEvent intEvent;
}

[Serializable]
public struct FloatVariableSetter
{
    public FloatVariable floatVariable;
    public FloatEvent floatEvent;
}

[Serializable]
public struct BoolVariableSetter
{
    public BoolVariable boolVariable;
    public BoolEvent boolEvent;
}

[Serializable]
public struct Vector2VariableSetter
{
    public Vector2Variable vector2Variable;
    public Vector2Event vector2Event;
}

[Serializable]
public struct Vector3VariableSetter
{
    public Vector3Variable vector3Variable;
    public Vector3Event vector3Event;
}
