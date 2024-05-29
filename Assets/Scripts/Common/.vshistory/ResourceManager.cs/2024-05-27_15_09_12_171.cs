using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public static void Load<T>(string prefabName)
    {
        //prefabName --> prefabPath
        return Resources.Load<T>("");
    }
}
