using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    //加载文件

    //解析文件（string --> Dictionary<string, string>  prefabName --> prefabPath）

    public static T Load<T>(string prefabName) where T : Object
    {
        //prefabName --> prefabPath
        return Resources.Load<T>("");
    }
}
