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
    }

    private Dictionary<string, List<GameObject>> cache;

    public void Init()
    {

    }
}
