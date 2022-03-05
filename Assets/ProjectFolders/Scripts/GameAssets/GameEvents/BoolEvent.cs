using UnityEngine;

///<Summary> Bu class bool parametresi ile haberleşmeyi sağlamaktadır.
///Yani bir eventi true veya false olarak Raise etmemizi sağlar.
///Onu dinleyen bitün fonksiyonlarda bu true veya false parametresini alırlar ve kullanarak Invoke olurlar.
///Bu haberleşmeyi eventler ile yapmaktadır.</Summary>
///<see cref="GameEvent"/>
[CreateAssetMenu(fileName = "NewBoolEvent", menuName = "GameAssets/GameEvents/BoolEvent")]
public class BoolEvent : GameEvent
{
    private System.Action<bool> gameEvent;

    ///<Summary> Bu eventi dinleyecek olan fonksiyon eklenmektedir. </Summary>
    public void AddListener(System.Action<bool> action)
    {
        gameEvent += action;
    }
    
    ///<Summary> Bu eventi dinleyecek olan fonksiyon kaldırılmaktadır. </Summary>
    public void RemoveListener(System.Action<bool> action)
    {
        gameEvent -= action;
    }

    ///<Summary> Bu event raise edilmektedir. Dinleyecek olan bütün listenerlar bu raise işlemi sonrasında triggerlanırlar. </Summary>
    public void Raise(bool value)
    {
        gameEvent?.Invoke(value);
    }
}
