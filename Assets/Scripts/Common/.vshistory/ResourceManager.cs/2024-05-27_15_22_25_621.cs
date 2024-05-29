﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ResourceManager
{
    //作用：初始化类的静态数据成员
    //时机：类被加载时执行一次
    static ResourceManager()
    {
        //加载文件

        //解析文件（string --> Dictionary<string, string>  prefabName --> prefabPath）

    }

    public static string GetConfigFile()
    {
        string fromPath = Application.streamingAssetsPath + "/";
        UnityWebRequest request = UnityWebRequest.Get(fromPath);
        var operation = request.SendWebRequest();
        operation.completed += _ => { };
    }


    public static T Load<T>(string prefabName) where T : Object
    {
        //prefabName --> prefabPath
        return Resources.Load<T>("");
    }
}