using System;
using UnityEngine;

///<Summary> Bu class oluşturulan variableının farklı classlarda çağırılıp okunmasını sağlamaktadır. 
/// Eğer Vector2 a cast edilerek kullanılırsa refere edilmiş valueyu dönmektedir.(ex: (Vector2)myFloatReference )</Summary>
[Serializable]
public class Vector2Reference
{
    public bool UseConstant = true;
    public Vector2 ConstantValue;
    public Vector2Variable Variable;

    public Vector2Reference() { }
     
    public Vector2Reference(Vector2 value)
    {
        UseConstant = true;
        ConstantValue = value;
    }

    /// <value> Property <c> Value </c> Bu reference ait olan variableın değerini dönmektedir. 
    ///Eğer sabir bir değer girildiyse onu döner. </value>
    public Vector2 Value{ get => UseConstant ? ConstantValue : Variable.Value; }

    public static implicit operator Vector2(Vector2Reference reference) => reference.Value;
}
