using System;

///<Summary> Bu class oluşturulan variableının farklı classlarda çağırılıp okunmasını sağlamaktadır. 
/// Eğer int a cast edilerek kullanılırsa refere edilmiş valueyu dönmektedir.(ex: (int)myFloatReference )</Summary>
[Serializable]
public class IntReference 
{
    public bool UseConstant = true;
    public int ConstantValue;
    public IntVariable Variable;

    public IntReference() { }

    public IntReference(int value)
    {
        UseConstant = true;
        ConstantValue = value;
    }

    /// <value> Property <c> Value </c> Bu reference ait olan variableın değerini dönmektedir. 
    ///Eğer sabir bir değer girildiyse onu döner. </value>
    public int Value{ get => UseConstant ? ConstantValue : Variable.Value; }
    
    public static implicit operator int(IntReference reference) => reference.Value;
}