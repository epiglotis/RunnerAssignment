using UnityEngine;

///<Summary> Bu class oyun içerisinde haberleşmeye sağlamaktadır.
///Burada bir adet float değişkeni bu classa yazılır ve onu realtime okuyan bitün classlar bu değeri set etmektedir.
///Bu haberleşmeyi variablelar ile yapmaktadır.</Summary>
///<see cref="GameVariable"/>
[CreateAssetMenu(fileName = "NewFloatVariable", menuName = "GameAssets/GameVariables/FloatVariable")]
public class FloatVariable : GameVariable
{
    public float Value { get => savedValue; }

    [Tooltip("Oyun her başladığında değer kaçta kalmış olursa olsun variableın başlayacağı değerdir. Bir nevi resetable variable yapılmaktadır. Sadece oyun başında setlenir.")]
    [SerializeField] private float initialValue;
    [SerializeField] protected bool useVariableLimits;
    [SerializeField] private float minValue;
    [SerializeField] private float maxValue;

    private float savedValue;

    private void OnEnable() 
    {
        if(!useInitialValue) return;
        savedValue = initialValue;
    }

    ///<Summary> Float ile değer ataması yapılmaktadır.</Summary>
    public void SetValue(float amount) => savedValue = (useVariableLimits) ? Mathf.Clamp(amount, minValue, maxValue) : amount;

    ///<Summary> FloatVariable ile değer ataması yapılmaktadır.</Summary>
    public void SetValue(FloatVariable amount) => savedValue = (useVariableLimits) ? Mathf.Clamp(amount.Value, minValue, maxValue) : amount.Value;

    ///<Summary> FloatReference ile değer ataması yapılmaktadır.</Summary>
    public void SetValue(FloatReference amount) => savedValue = (useVariableLimits) ?  Mathf.Clamp(amount.Value, minValue, maxValue) : amount.Value;

    ///<Summary> Variable'a 1 eklemektedir.</Summary>
    public void Increase() => savedValue = (useVariableLimits) ? Mathf.Clamp(savedValue + 1, minValue, maxValue) : savedValue + 1;

    ///<Summary> Float ile toplama yapılmaktadır.</Summary>
    public void Increase(float amount) => savedValue = (useVariableLimits) ? Mathf.Clamp(savedValue + amount, minValue, maxValue) : savedValue + amount;

    ///<Summary> FloatVariable ile toplama yapılmaktadır.</Summary>
    public void Increase(FloatVariable amount) => savedValue = (useVariableLimits) ? Mathf.Clamp(savedValue + amount.Value, minValue, maxValue) : savedValue + amount.Value;

    ///<Summary> FloatReference ile toplama yapılmaktadır.</Summary>
    public void Increase(FloatReference amount) => savedValue = (useVariableLimits) ? Mathf.Clamp(savedValue + amount.Value, minValue, maxValue) : savedValue + amount.Value;

    ///<Summary> Variable'dan 1 çıkartmaktadır.</Summary>
    public void Decrease() => savedValue = (useVariableLimits) ? Mathf.Clamp(savedValue - 1, minValue, maxValue) : savedValue - 1;

    ///<Summary> Float ile çıkarma yapılmaktadır.</Summary>
    public void Decrease(float amount) => savedValue = (useVariableLimits) ? Mathf.Clamp(savedValue - amount, minValue, maxValue) : savedValue - amount;

    ///<Summary> FloatVariable ile çıkarma yapılmaktadır.</Summary>
    public void Decrease(FloatVariable amount) => savedValue = (useVariableLimits) ? Mathf.Clamp(savedValue - amount.Value, minValue, maxValue) : savedValue - amount.Value;

    ///<Summary> FloatReference ile çıkarma yapılmaktadır.</Summary>
    public void Decrease(FloatReference amount) => savedValue = (useVariableLimits) ? Mathf.Clamp(savedValue - amount.Value, minValue, maxValue) : savedValue - amount.Value;

    ///<Summary> Float ile çarpma yapılmaktadır.</Summary>
    public void Multiply(float multiplier) => savedValue = (useVariableLimits) ? Mathf.Clamp(savedValue * multiplier, minValue, maxValue) : savedValue * multiplier;

    ///<Summary> FloatVariable ile çarpma yapılmaktadır.</Summary>
    public void Multiply(FloatVariable multiplier) => savedValue = (useVariableLimits) ? Mathf.Clamp(savedValue * multiplier.Value, minValue, maxValue) : savedValue * multiplier.Value;

    ///<Summary> FloatReference ile çarpma yapılmaktadır.</Summary>
    public void Multiply(FloatReference multiplier) => savedValue = (useVariableLimits) ? Mathf.Clamp(savedValue * multiplier.Value, minValue, maxValue) : savedValue * multiplier.Value;

    ///<Summary> Float ile bölme yapılmaktadır.</Summary>
    public void Devide(float divider) => savedValue = (useVariableLimits) ? Mathf.Clamp(savedValue / divider, minValue, maxValue) : (savedValue / divider);

    ///<Summary> FloatVariable ile bölme yapılmaktadır.</Summary>
    public void Devide(FloatVariable divider) => savedValue = (useVariableLimits) ? Mathf.Clamp(savedValue / divider.Value, minValue, maxValue) : (savedValue / divider.Value);
    
    ///<Summary> FloatReference ile bölme yapılmaktadır.</Summary>
    public void Devide(FloatReference divider) => savedValue = (useVariableLimits) ? Mathf.Clamp(savedValue / divider.Value, minValue, maxValue) : (savedValue / divider.Value);
}