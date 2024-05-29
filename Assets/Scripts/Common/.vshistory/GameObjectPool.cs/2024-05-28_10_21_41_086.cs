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

    /// <summary>
    /// 使用对象池
    /// </summary>
    /// <param name="key">类别</param>
    /// <param name="prefab">需要创建实例的预制件</param>
    /// <param name="position"></param>
    /// <param name="rotation"></param>
    /// <returns></returns>
    public GameObject CreateObject(string key, GameObject prefab, Vector3 position, Quaternion rotation)
    {
        GameObject go = FindUsableObject(key);
        if (go == null)
        {
            go = AddObject(key, prefab);
        }

        UseObject(position, rotation, go);
        return go;
    }

    //查找
    private GameObject FindUsableObject(string key)
    {
        if (cache.ContainsKey(key))
            return cache[key].Find(g => !g.activeInHierarchy);
        return null;
    }

    //添加
    private GameObject AddObject(string key, GameObject prefab)
    {
        GameObject go = Instantiate(prefab);
        if (!cache.ContainsKey(key))
            cache.Add(key, new List<GameObject>());
        cache[key].Add(go);
        return go;
    }

    //使用
    private void UseObject(Vector3 position, Quaternion rotation, GameObject go)
    {
        go.transform.position = position;
        go.transform.rotation = rotation;
        go.SetActive(true);
    }

    //回收
    public void CollectObject(GameObject go, float delay = 0)
    {
        StartCoroutine(CollectObjectDelay(go, delay));
    }
    private IEnumerator CollectObjectDelay(GameObject go, float delay)
    {
        yield return new WaitForSeconds(delay);
        go.SetActive(false);
    }

    //清空某个类别的缓存
    public void Clear(string key)
    {
        if (!cache.ContainsKey(key)) return;

        //list删除的时候，中间的被删了，后面的会往前一个位置
        /*for (int i = cache[key].Count - 1; i >= 0; i--)
        {
            Destroy(cache[key][i]);
        }*/
        foreach (var item in cache[key])
            Destroy(item);

        cache.Remove(key);
    }

    public void ClearAll()
    {
        /*
        //有问题不能删除字典的key
        foreach (var key in cache.Keys) //遍历字典集合
        {
            Clear(key); //删除字典集合
        }*/

        foreach (var key in new List<string>(cache.Keys))
        {
            Clear(key);
        }

        /*List<string> keyList = new List<string>(cache.Keys); //遍历List集合
        foreach (var key in keyList)
            Clear(key); // 删除字典记录 */
    }
}
