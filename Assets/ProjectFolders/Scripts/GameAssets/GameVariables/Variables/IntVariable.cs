using UnityEngine;

///<Summary> Bu class oyun içerisinde haberleşmeye sağlamaktadır.
///Burada bir adet int değişkeni bu classa yazılır ve onu realtime okuyan bitün classlar bu değeri set etmektedir.
///Bu haberleşmeyi variablelar ile yapmaktadır.</Summary>
///<see cref="GameVariable"/>
[CreateAssetMenu(fileName = "NewIntVariable", menuName = "GameAssets/GameVariables/IntVariable")]
public class IntVariable : GameVariable
{
    public int Value { get => savedValue; }

    [Tooltip("Oyun her başladığında değer kaçta kalmış olursa olsun variableın başlayacağı değerdir. Bir nevi resetable variable yapılmaktadır. Sadece oyun başında setlenir.")]
    [SerializeField] private int initialValue;
    [SerializeField] private bool useVariableLimits;
    [SerializeField] private int minValue;
    [SerializeField] private int maxValue;

    private int savedValue;

    private void OnEnable() 
    {
        SetSavedValue();
    }

    void SetSavedValue(){

        if(!useInitialValue) return;
        savedValue = initialValue;

    }

    ///<Summary> Initial Value'yu oyun içerisinde değiştirir. </Summary>
    public void ChangeInitialValue(int amount){

        if(useVariableLimits == true){

            initialValue = Mathf.Clamp(amount,minValue,maxValue);
            SetSavedValue();

        }
        else{

            initialValue = amount;
            SetSavedValue();

        }
    }

    ///<Summary> Int ile değer ataması yapılmaktadır.</Summary>
    public void SetValue(int amount) => savedValue = (useVariableLimits) ? Mathf.Clamp(amount,minValue,maxValue) : amount;

    ///<Summary> IntVariable ile değer ataması yapılmaktadır.</Summary>
    public void SetValue(IntVariable amount) => savedValue = (useVariableLimits) ? Mathf.Clamp(amount.Value, minValue, maxValue) : amount.Value;

    ///<Summary> IntReference ile değer ataması yapılmaktadır.</Summary>
    public void SetValue(IntReference amount) => savedValue = (useVariableLimits) ? Mathf.Clamp(amount.Value, minValue, maxValue) : amount.Value;

    ///<Summary> Variable'a 1 eklemektedir.</Summary>
    public void Increase() => savedValue = (useVariableLimits) ? Mathf.Clamp(savedValue + 1, minValue, maxValue) : savedValue + 1;

    ///<Summary> Int ile toplama yapılmaktadır.</Summary>
    public void Increase(int amount) => savedValue = (useVariableLimits) ? Mathf.Clamp(savedValue + amount, minValue, maxValue) : savedValue + amount;

    ///<Summary> IntVariable ile toplama yapılmaktadır.</Summary>
    public void Increase(IntVariable amount) => savedValue = (useVariableLimits) ? Mathf.Clamp(savedValue + amount.Value, minValue, maxValue) : savedValue + amount.Value;

    ///<Summary> IntReference ile toplama yapılmaktadır.</Summary>
    public void Increase(IntReference amount) => savedValue = (useVariableLimits) ? Mathf.Clamp(savedValue + amount.Value, minValue, maxValue) : savedValue + amount.Value;

    ///<Summary> Variable'dan 1 çıkartmaktadır.</Summary>
    public void Decrease() => savedValue = (useVariableLimits) ? Mathf.Clamp(savedValue - 1, minValue, maxValue) : savedValue - 1;

    ///<Summary> Int ile çıkarma yapılmaktadır.</Summary>
    public void Decrease(int amount) => savedValue = (useVariableLimits) ? Mathf.Clamp(savedValue - amount, minValue, maxValue) : savedValue - amount;

    ///<Summary> IntVariable ile çıkarma yapılmaktadır.</Summary>
    public void Decrease(IntVariable amount) => savedValue = (useVariableLimits) ? Mathf.Clamp(savedValue - amount.Value, minValue, maxValue) : savedValue - amount.Value;

    ///<Summary> IntReference ile çıkarma yapılmaktadır.</Summary>
    public void Decrease(IntReference amount) => savedValue = (useVariableLimits) ? Mathf.Clamp(savedValue - amount.Value, minValue, maxValue) : savedValue - amount.Value;

    ///<Summary> Int ile çarpma yapılmaktadır.</Summary>
    public void Multiply(int multiplier) => savedValue = (useVariableLimits) ? Mathf.Clamp(savedValue * multiplier, minValue, maxValue) : savedValue * multiplier;

    ///<Summary> IntVariable ile çarpma yapılmaktadır.</Summary>
    public void Multiply(IntVariable multiplier) => savedValue = (useVariableLimits) ? Mathf.Clamp(savedValue * multiplier.Value, minValue, maxValue) : savedValue * multiplier.Value;

    ///<Summary> IntReference ile çarpma yapılmaktadır.</Summary>
    public void Multiply(IntReference multiplier) => savedValue = (useVariableLimits) ? Mathf.Clamp(savedValue * multiplier.Value, minValue, maxValue) : savedValue * multiplier.Value;

    ///<Summary> Int ile bölme yapılmaktadır.
    /// Eğer bölümün sonucu ondalıklı ise en yakın olan tam sayıya tamamlanır.</Summary>
    public void Divide(int divider) => savedValue = (useVariableLimits) ? Mathf.Clamp(Mathf.RoundToInt(savedValue / divider), minValue, maxValue) : Mathf.RoundToInt(savedValue / divider);

    ///<Summary> IntVariable ile bölme yapılmaktadır.
    /// Eğer bölümün sonucu ondalıklı ise en yakın olan tam sayıya tamamlanır.</Summary>
    public void Divide(IntVariable divider) => savedValue = (useVariableLimits) ? Mathf.Clamp(Mathf.RoundToInt(savedValue / divider.Value), minValue, maxValue) : Mathf.RoundToInt(savedValue / divider.Value);

    ///<Summary> IntReference ile bölme yapılmaktadır.
    /// Eğer bölümün sonucu ondalıklı ise en yakın olan tam sayıya tamamlanır.</Summary>
    public void Divide(IntReference divider) => savedValue = (useVariableLimits) ? Mathf.Clamp(Mathf.RoundToInt(savedValue / divider.Value), minValue, maxValue) : Mathf.RoundToInt(savedValue / divider.Value);
}