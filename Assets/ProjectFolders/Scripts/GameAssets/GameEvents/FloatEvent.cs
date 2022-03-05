using UnityEngine;

///<Summary> Bu class float parametresi ile haberleşmeyi sağlamaktadır.
///Yani bir eventi float olarak Raise etmemizi sağlar.
///Onu dinleyen bitün fonksiyonlarda bu float parametresini alırlar ve kullanarak Invoke olurlar.
///Bu haberleşmeyi eventler ile yapmaktadır.</Summary>
///<see cref="GameEvent"/>
[CreateAssetMenu(fileName = "NewFloatEvent", menuName = "GameAssets/GameEvents/FloatEvent")]
public class FloatEvent : GameEvent
{
    private System.Action<float> gameEvent;

    ///<Summary> Bu eventi dinleyecek olan fonksiyon eklenmektedir. </Summary>
    public void AddListener(System.Action<float> action)
    {
        gameEvent += action;
    }
    
    ///<Summary> Bu eventi dinleyecek olan fonksiyon kaldırılmaktadır. </Summary>
    public void RemoveListener(System.Action<float> action)
    {
        gameEvent -= action;
    }

    ///<Summary> Bu event raise edilmektedir. Dinleyecek olan bütün listenerlar bu raise işlemi sonrasında triggerlanırlar. </Summary>
    public void Raise(float value)
    {
        gameEvent?.Invoke(value);
    }
}
