using UnityEngine;

///<Summary> Bu class oyun içerisinde haberleşmeye sağlamaktadır.
///Burada bir adet Vector2 değişkeni bu classa yazılır ve onu realtime okuyan bitün classlar bu değeri set etmektedir.
///Bu haberleşmeyi variablelar ile yapmaktadır.</Summary>
///<see cref="GameVariable"/>
[CreateAssetMenu(fileName = "NewVector2Variable", menuName = "GameAssets/GameVariables/Vector2Variable")]
public class Vector2Variable : GameVariable
{
    public Vector2 Value { get => savedValue; }

    [Tooltip("Oyun her başladığında değer kaçta kalmış olursa olsun variableın başlayacağı değerdir. Bir nevi resetable variable yapılmaktadır. Sadece oyun başında setlenir.")]
    [SerializeField] private Vector2 initialValue;

    private Vector2 savedValue;

    private void OnEnable() 
    {
        if(!useInitialValue) return;
        savedValue = initialValue;
    }

    ///<Summary> Float ile değer ataması yapılmaktadır.</Summary>
    public void SetValue(Vector2 amount) => savedValue = amount;

    ///<Summary> FloatVariable ile değer ataması yapılmaktadır.</Summary>
    public void SetValue(Vector2Variable amount) => savedValue = amount.Value;

    ///<Summary> Float ile scale yapılmaktadır.</Summary>
    public void Scale(float multiplier) => savedValue *= multiplier;

    ///<Summary> İnt ile scale yapılmaktadır.</Summary>
    public void Scale(int multiplier) => savedValue *= multiplier;

    ///<Summary> FloatVariable ile scale yapılmaktadır.</Summary>
    public void Scale(FloatVariable multiplier) => savedValue *= multiplier.Value;

    ///<Summary> FloatReference ile scale yapılmaktadır.</Summary>
    public void Scale(FloatReference multiplier) => savedValue *= multiplier.Value;

    ///<Summary> IntVariable ile scale yapılmaktadır.</Summary>
    public void Scale(IntVariable multiplier) => savedValue *= multiplier.Value;

    ///<Summary> IntReference ile scale yapılmaktadır.</Summary>
    public void Scale(IntReference multiplier) => savedValue *= multiplier.Value;
}
