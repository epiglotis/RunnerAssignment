using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pooler", menuName = "ObjectPooling/Pooler")]
public class Pooler : ScriptableObject
{
    [SerializeField] private PooledItem pooledPrefab;
    [SerializeField] private bool prewarm = false;
    [SerializeField] private int prewarmCount = 0;
    private List<PooledItem> spawnedItems = new List<PooledItem>();

    private void OnEnable() 
    {
        if(prewarm) PrewarmSpawn(prewarmCount); 
    }

    private void PrewarmSpawn(int prewarmCount)
    {
        for(int i = 0; i < prewarmCount; i++)
        {
            PooledItem pooledItem = Spawn();
            pooledItem.gameObject.SetActive(false);
        }
    } 

    ///<Summary> Position, rotation ve parent önemsenmeksizin spawn işlemi yapılmaktadır.
    /// Spawn edilecek objenin position değeri 0,0,0 dır, rotation değeri identitydir ve parenti yoktur.. </Summary>
    public PooledItem Spawn()
    {
        PooledItem pooledItem = GetAvaiableItemInPool();
        if(spawnedItems.Count > 0 && pooledItem != null && !pooledItem.gameObject.activeInHierarchy)
        {
            //Release olmayı bekliyen objelerin taski iptal eilecek ve respawn edilecekler.
            return Respawn(pooledItem, Vector3.zero, Quaternion.identity, null);
        }
        
        return InstantiatePrefab(Vector3.zero, Quaternion.identity, null);
    }

    ///<Summary> Spawn edilecek objenin sadece parenti bellidir.
    /// Spawn edilecek objenin position değeri 0,0,0 dır, rotation değeri identitydir. </Summary>
    public PooledItem Spawn(Transform parent)
    {
        PooledItem pooledItem = GetAvaiableItemInPool();
        if(spawnedItems.Count > 0 && pooledItem != null && !pooledItem.gameObject.activeInHierarchy)
        {
            //Release olmayı bekliyen objelerin taski iptal eilecek ve respawn edilecekler.
            return Respawn(pooledItem, Vector3.zero, Quaternion.identity, parent);;
        }

        return InstantiatePrefab(Vector3.zero, Quaternion.identity, parent);
    }

    ///<Summary> Position ve rotation değerleriyle spawn işlemi yapılmaktadır. Parent dahil değildir. 
    /// Obje World de belirtilen postion ve rotaion ile parentsız bir şekilde instantiate edilir. </Summary>
    public PooledItem Spawn(Vector3 position, Quaternion rotation)
    {
        PooledItem pooledItem = GetAvaiableItemInPool();
        if(spawnedItems.Count > 0 && pooledItem != null && !pooledItem.gameObject.activeInHierarchy)
        {
            //Release olmayı bekliyen objelerin taski iptal eilecek ve respawn edilecekler.
            return Respawn(pooledItem, position, rotation, null);
        }

        return InstantiatePrefab(position, rotation, null);
    }

    ///<Summary> Spawn edilecek objenin position, rotaion ve parenti bellidir. Oraya spawn edilir. </Summary>
    public PooledItem Spawn(Vector3 position, Quaternion rotation, Transform parent)
    {
        PooledItem pooledItem = GetAvaiableItemInPool();
        if(spawnedItems.Count > 0 && pooledItem != null && !pooledItem.gameObject.activeInHierarchy)
        {
            //Release olmayı bekliyen objelerin taski iptal eilecek ve respawn edilecekler.
            return Respawn(pooledItem, position, rotation, parent);
        }

        return InstantiatePrefab(position, rotation, parent);
    }

    ///<Summary> Spawnerda on disable fonksiyonunda çağırılır ve listin içerisindeki objeleri temizler. </Summary>
    public void Clear() => spawnedItems.Clear();

    //Bu fonksiyonda uygun olan yani oyunda deactive olan ve ilk instantiate edilmiş olan pooledItem return edilmektedir.
    private PooledItem GetAvaiableItemInPool()
    {
        for(int i = 0; i < spawnedItems.Count; i++) if(!spawnedItems[i].gameObject.activeInHierarchy) return spawnedItems[i];
        return null;
    }

    //Respawn Methodu bir obje eğer bundleına geri gönderilmediyse yani release edilmediyse, 
    // o objeyi tekrar kallanmak için çağırılacak fonksiyon.
    private PooledItem Respawn(PooledItem itemToRespawn,Vector3 position, Quaternion rotation, Transform parent)
    {
        itemToRespawn.transform.position = position;
        itemToRespawn.transform.rotation = rotation;
        itemToRespawn.transform.SetParent(parent);
        itemToRespawn.transform.gameObject.SetActive(true);
        return itemToRespawn;
    }

    //Bu Fonksiyon prefabı instantiate edip queueya ekleme ve return fonksiyonunu register etme işlemi yapmaktadır.
    private PooledItem InstantiatePrefab(Vector3 position, Quaternion rotation, Transform parent)
    {
        PooledItem pooledItem = Instantiate(pooledPrefab, position, rotation, parent);
        pooledItem.onReturnToPool += ReturnToPool;
        spawnedItems.Add(pooledItem);
        return pooledItem;
    }

    //Bu method objenin poola dönmesini sağlar.
    private void ReturnToPool(PooledItem itemToReturn) => itemToReturn.gameObject.SetActive(false);
}
