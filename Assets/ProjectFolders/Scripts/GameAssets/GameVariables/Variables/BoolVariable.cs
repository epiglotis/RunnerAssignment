using UnityEngine;

///<Summary> Bu class oyun içerisinde haberleşmeye sağlamaktadır.
///Burada bir adet bool değişkeni bu classa yazılır ve onu realtime okuyan bitün classlar bu değeri set etmektedir.
///Bu haberleşmeyi variablelar ile yapmaktadır.</Summary>
///<see cref="GameVariable"/>
[CreateAssetMenu(fileName = "NewBoolVariable", menuName = "GameAssets/GameVariables/BoolVariable")]
public class BoolVariable : GameVariable
{
    public bool Value { get => savedValue; }

    [Tooltip("Oyun her başladığında değer kaçta kalmış olursa olsun variableın başlayacağı değerdir. Bir nevi resetable variable yapılmaktadır. Sadece oyun başında setlenir.")]
    [SerializeField] private bool initialValue;

    private bool savedValue;

    private void OnEnable() 
    {
        if(!useInitialValue) return;
        savedValue = initialValue;
    }

    ///<Summary> Bool ile değer ataması yapılmaktadır.</Summary>
    public void SetValue(bool amount) => savedValue = amount;

    ///<Summary> BoolVariable ile değer ataması yapılmaktadır.</Summary>
    public void SetValue(BoolVariable amount) => savedValue = amount.Value;

    ///<Summary> BoolReference ile değer ataması yapılmaktadır.</Summary>
    public void SetValue(BoolReference amount) => savedValue = amount.Value;

    ///<Summary> Bu fonksiyon variable true ise false, false ise true yapmaktadır.</Summary>
    public void ToggleValue() => savedValue = !savedValue;
}
