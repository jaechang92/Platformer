using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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



    [SerializeField]
    public List<GameObject> objectsPool = new List<GameObject>();

    int poolSize = 20;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            objectsPool.Add(Instantiate(prefab,Vector3.zero,Quaternion.identity, this.transform));
            objectsPool[i].SetActive(false);
        }
        //StartCoroutine(CreTest());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator CreTest()
    {
        while (true)
        {
            GameObject temp;
            temp = objectsPool[0];
            temp.SetActive(true);
            Debug.Log(this.transform.root.name);
            temp.transform.SetParent(null);
            objectsPool.RemoveAt(0);
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void PushOfObjectPool(List<GameObject> PoolName, GameObject PushObject)
    {
        PoolName.Add(PushObject);
        PushObject.transform.SetParent(this.transform);
    }

    public void PullOfObjectPool(List<GameObject> PoolName)
    {
        if (PoolName.Count != 0)
        {
            GameObject temp = PoolName[0];
            temp.transform.SetParent(null);
            temp.SetActive(true);
            PoolName.Remove(temp);
        }
        else
        {
            GameObject temp = Instantiate(prefab, Vector3.zero, Quaternion.identity, this.transform);
            PoolName.Add(temp);
            temp.SetActive(false);

            temp = PoolName[0];
            temp.transform.SetParent(null);
            temp.SetActive(true);
            PoolName.Remove(temp);
        }

    }


}
