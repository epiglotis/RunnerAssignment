using System;
using UnityEngine;

///<Summary> Bu class oluşturulan variableının farklı classlarda çağırılıp okunmasını sağlamaktadır. 
/// Eğer Vector3 a cast edilerek kullanılırsa refere edilmiş valueyu dönmektedir.(ex: (Vector3)myFloatReference )</Summary>
[Serializable]
public class Vector3Reference
{
    public bool UseConstant = true;
    public Vector3 ConstantValue;
    public Vector3Variable Variable;
    
    public Vector3Reference() { }

    public Vector3Reference(Vector3 value)
    {
        UseConstant = true;
        ConstantValue = value;
    }

    /// <value> Property <c> Value </c> Bu reference ait olan variableın değerini dönmektedir. 
    ///Eğer sabir bir değer girildiyse onu döner. </value>
    public Vector3 Value{ get => UseConstant ? ConstantValue : Variable.Value; }

    public static implicit operator Vector3(Vector3Reference reference) => reference.Value;
}
