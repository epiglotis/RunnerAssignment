using UnityEngine;
public class PooledItem : MonoBehaviour
{
    [Tooltip("Eğer object kendi başına poola dönecekse bu eventi raise etmesi gerekmektedir. Bu eventi raise edince pooler bu objeyi poola geri alacaktır.")]
    public System.Action<PooledItem> onReturnToPool;

    private void OnEnable() {
        Invoke("ReturnToPool",1f);
    }

    ///<Summary> Bu fonksiyon objeyi poola gönderecek olan eventi raise etmektedir.
    /// Bu fonksiyon direkt belirli bir koşula bağlı olarak poollanan obje tarafından da yapılabilir.
    /// Veya bu objeyi handle eden class tarafından da yapılabilir. </Summary>
    protected void ReturnToPool()
    {
        onReturnToPool?.Invoke(this);
    }
}