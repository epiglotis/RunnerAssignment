using System;

///<Summary> Bu class oluşturulan variableının farklı classlarda çağırılıp okunmasını sağlamaktadır. 
/// Eğer bool a cast edilerek kullanılırsa refere edilmiş valueyu dönmektedir.(ex: (bool)myFloatReference )</Summary>
[Serializable]
public class BoolReference
{
    public bool UseConstant = true;
    public bool ConstantValue;
    public BoolVariable Variable;

    public BoolReference() { }

    public BoolReference(bool value)
    {
        UseConstant = true;
        ConstantValue = value;
    }

    /// <value> Property <c> Value </c> Bu reference ait olan variableın değerini dönmektedir. 
    ///Eğer sabir bir değer girildiyse onu döner. </value>
    public bool Value{ get => UseConstant ? ConstantValue : Variable.Value; }

    public static implicit operator bool(BoolReference reference) => reference.Value;
}
