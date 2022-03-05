using UnityEngine;

///<Summary> Bu class Vector2 parametresi ile haberleşmeyi sağlamaktadır.
///Yani bir eventi Vector2 olarak Raise etmemizi sağlar.
///Onu dinleyen bitün fonksiyonlarda bu Vector2 parametresini alırlar ve kullanarak Invoke olurlar.
///Bu haberleşmeyi eventler ile yapmaktadır.</Summary>
///<see cref="GameEvent"/>
[CreateAssetMenu(fileName = "NewVector2Event", menuName = "GameAssets/GameEvents/Vector2Event")]
public class Vector2Event : GameEvent
{
    private System.Action<Vector2> gameEvent;

    ///<Summary> Bu eventi dinleyecek olan fonksiyon eklenmektedir. </Summary>
    public void AddListener(System.Action<Vector2> action)
    {
        gameEvent += action;
    }
    
    ///<Summary> Bu eventi dinleyecek olan fonksiyon kaldırılmaktadır. </Summary>
    public void RemoveListener(System.Action<Vector2> action)
    {
        gameEvent -= action;
    }

    ///<Summary> Bu event raise edilmektedir. Dinleyecek olan bütün listenerlar bu raise işlemi sonrasında triggerlanırlar. </Summary>
    public void Raise(Vector2 value)
    {
        gameEvent?.Invoke(value);
    }
}
