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
        GameObject go = FindUsableObject(key);
        if (go == null)
        {
            go = AddObject(key, prefab);
        }

        go.transform.position = position;
        go.transform.rotation = rotation;
        go.SetActive(true);
        return go;
    }

    private GameObject FindUsableObject(string key)
    {
        if (cache.ContainsKey(key))
            return cache[key].Find(g => !g.activeInHierarchy);
        return null;
    }

    private GameObject AddObject(string key, GameObject prefab)
    {
        GameObject go = Instantiate(prefab);
        if (!cache.ContainsKey(key))
            cache.Add(key, new List<GameObject>());
        cache[key].Add(go);
        return go;
    }

}
