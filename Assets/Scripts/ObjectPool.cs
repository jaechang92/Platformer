using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public string poolName;
    public List<GameObject> list = new List<GameObject>();
    public int poolSize;
    public GameObject prefab;
}


public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public Pool[] pool;


    //[SerializeField]
    //public List<GameObject> objectsPool,itemPool = new List<GameObject>();

    //public int itemPoolSize;
    //int poolSize = 20;
    //public GameObject objectsPrefab;
    //public GameObject itemPrefab;
    // Start is called before the first frame update

    void Start()
    {
        foreach (var item in pool)
        {
            GameObject tmp;
            for (int i = 0; i < item.poolSize; i++)
            {
                tmp = Instantiate(item.prefab, Vector3.zero, Quaternion.identity, this.transform);
                item.list.Add(tmp);
                tmp.SetActive(false);
            }
        }

        //for (int i = 0; i < poolSize; i++)
        //{
        //    objectsPool.Add(Instantiate(objectsPrefab, Vector3.zero, Quaternion.identity, this.transform));
        //    objectsPool[i].SetActive(false);
        //}

        //for (int j = 0; j < itemPoolSize; j++)
        //{
        //    itemPool.Add(Instantiate(itemPrefab, Vector3.zero, Quaternion.identity, this.transform));
        //    itemPool[j].SetActive(false);
        //}

        //StartCoroutine(CreTest());
    }



    //IEnumerator CreTest()
    //{
    //    while (true)
    //    {
    //        GameObject temp;
    //        temp = objectsPool[0];
    //        temp.SetActive(true);
    //        Debug.Log(this.transform.root.name);
    //        temp.transform.SetParent(null);
    //        objectsPool.RemoveAt(0);
    //        yield return new WaitForSeconds(1.0f);
    //    }
    //}

    public void PushOfObjectPool(List<GameObject> PoolName, GameObject PushObject)
    {
        PoolName.Add(PushObject);
        PushObject.transform.SetParent(this.transform);
    }

    public GameObject PullOfObjectPool(Pool PoolName)
    {
        GameObject tmp;
        if (PoolName.list.Count != 0)
        {
            tmp = PoolName.list[0];
            tmp.transform.SetParent(null);
            tmp.SetActive(true);
            PoolName.list.Remove(tmp);
        }
        else
        {
            tmp = Instantiate(PoolName.prefab, Vector3.zero, Quaternion.identity, this.transform);
            PoolName.list.Add(tmp);
            tmp.SetActive(false);

            tmp = PoolName.list[0];
            tmp.transform.SetParent(null);
            tmp.SetActive(true);
            PoolName.list.Remove(tmp);
        }
        return tmp;
    }


}
