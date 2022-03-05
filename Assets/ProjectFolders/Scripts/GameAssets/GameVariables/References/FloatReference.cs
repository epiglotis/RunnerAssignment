using System;

///<Summary> Bu class oluşturulan variableının farklı classlarda çağırılıp okunmasını sağlamaktadır. 
/// Eğer float a cast edilerek kullanılırsa refere edilmiş valueyu dönmektedir.(ex: (float)myFloatReference )</Summary>
[Serializable]
public class FloatReference
{
    public bool UseConstant = true;
    public float ConstantValue;
    public FloatVariable Variable;

    public FloatReference() { }

    public FloatReference(float value)
    {
        UseConstant = true;
        ConstantValue = value;
    }

    /// <value> Property <c> Value </c> Bu reference ait olan variableın değerini dönmektedir. 
    ///Eğer sabir bir değer girildiyse onu döner. </value>
    public float Value{ get => UseConstant ? ConstantValue : Variable.Value; }

    public static implicit operator float(FloatReference reference) => reference.Value;
}
