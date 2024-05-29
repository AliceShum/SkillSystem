using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public static T Load<T>(string prefabName) where T : Object
    {
        //prefabName --> prefabPath
        return Resources.Load<T>("");
    }
}
