using UnityEngine;
///<Summary> Bu class oyun içerisinde haberleşmeye sağlamaktadır. 
///Bu haberleşmeyi variablelar ile yapmaktadır.</Summary>
///<see cref="GameAsset"/>
public class GameVariable : GameAsset 
{ 
    [Tooltip("Oyunun her başlangıcında değeri reset etmeyi temsil eder. Eğer variable resetable ise true, değilse false olmalıdır.")]
    [SerializeField] protected bool useInitialValue;
}