using UnityEngine;

///<Summary> Bu class int parametresi ile haberleşmeyi sağlamaktadır.
///Yani bir eventi int olarak Raise etmemizi sağlar.
///Onu dinleyen bitün fonksiyonlarda bu int parametresini alırlar ve kullanarak Invoke olurlar.
///Bu haberleşmeyi eventler ile yapmaktadır.</Summary>
///<see cref="GameEvent"/>
[CreateAssetMenu(fileName = "NewIntEvent", menuName = "GameAssets/GameEvents/IntEvent")]
public class IntEvent : GameEvent
{
    private System.Action<int> gameEvent;

    ///<Summary> Bu eventi dinleyecek olan fonksiyon eklenmektedir. </Summary>
    public void AddListener(System.Action<int> action)
    {
        gameEvent += action;
    }
    
    ///<Summary> Bu eventi dinleyecek olan fonksiyon kaldırılmaktadır. </Summary>
    public void RemoveListener(System.Action<int> action)
    {
        gameEvent -= action;
    }

    ///<Summary> Bu event raise edilmektedir. Dinleyecek olan bütün listenerlar bu raise işlemi sonrasında triggerlanırlar. </Summary>
    public void Raise(int value)
    {
        gameEvent?.Invoke(value);
    }
}
