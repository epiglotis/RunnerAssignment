using UnityEngine;

///<Summary> Bu class Vector3 parametresi ile haberleşmeyi sağlamaktadır.
///Yani bir eventi Vector3 olarak Raise etmemizi sağlar.
///Onu dinleyen bitün fonksiyonlarda bu Vector3 parametresini alırlar ve kullanarak Invoke olurlar.
///Bu haberleşmeyi eventler ile yapmaktadır.</Summary>
///<see cref="GameEvent"/>
[CreateAssetMenu(fileName = "NewVector3Event", menuName = "GameAssets/GameEvents/Vector3Event")]
public class Vector3Event : GameEvent
{
    private System.Action<Vector3> gameEvent;

    ///<Summary> Bu eventi dinleyecek olan fonksiyon eklenmektedir. </Summary>
    public void AddListener(System.Action<Vector3> action)
    {
        gameEvent += action;
    }
    
    ///<Summary> Bu eventi dinleyecek olan fonksiyon kaldırılmaktadır. </Summary>
    public void RemoveListener(System.Action<Vector3> action)
    {
        gameEvent -= action;
    }

    ///<Summary> Bu event raise edilmektedir. Dinleyecek olan bütün listenerlar bu raise işlemi sonrasında triggerlanırlar. </Summary>
    public void Raise(Vector3 value)
    {
        gameEvent?.Invoke(value);
    }
}
