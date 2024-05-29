using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    private static GameObjectPool instance;
    public static GameObjectPool Instance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
        Init();
    }

    private Dictionary<string, List<GameObject>> cache;

    public void Init()
    {
        cache = new Dictionary<string, List<GameObject>>();
    }

    public GameObject CreateObject(string key, GameObject prefab, Vector3 position, Quaternion rotation)
    {
        GameObject go = null;
        if (cache.ContainsKey(key))
            go = cache[key].Find(g => !g.activeInHierarchy);
        if (go == null)
        {
            go = Instantiate(prefab);
            if (!cache.ContainsKey(key))
                cache.Add(key, new List<GameObject>());
            cache[key].Add(go);
        }

        go.transform.position = position;
        go.transform.rotation = rotation;
        go.SetActive(true);
        return go;
    }

}
