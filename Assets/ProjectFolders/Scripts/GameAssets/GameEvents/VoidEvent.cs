using UnityEngine;

///<Summary> Bu class bool parametresi ile haberleşmeyi sağlamaktadır.
///Yani bir eventi parametresiz olarak Raise etmemizi sağlar.
///Onu dinleyen bitün fonksiyonlarda parametresiz olurlar ve direkt invoke olurlar.
///Bu haberleşmeyi eventler ile yapmaktadır.</Summary>
///<see cref="GameEvent"/>
[CreateAssetMenu(fileName = "NewVoidEvent", menuName = "GameAssets/GameEvents/VoidEvent")]
public class VoidEvent : GameEvent
{
    private System.Action gameEvent;

    ///<Summary> Bu eventi dinleyecek olan fonksiyon eklenmektedir. </Summary>
    public void AddListener(System.Action action)
    {
        gameEvent += action;
    }
    
    ///<Summary> Bu eventi dinleyecek olan fonksiyon kaldırılmaktadır. </Summary>
    public void RemoveListener(System.Action action)
    {
        gameEvent -= action;
    }

    ///<Summary> Bu event raise edilmektedir. Dinleyecek olan bütün listenerlar bu raise işlemi sonrasında triggerlanırlar. </Summary>
    public void Raise()
    {
        gameEvent?.Invoke();
    }
}
