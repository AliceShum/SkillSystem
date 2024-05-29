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
        string fromPath = Application.streamingAssetsPath + "/ConfigMap.txt";
        UnityWebRequest request = UnityWebRequest.Get(fromPath);
        var operation = request.SendWebRequest();
        //operation.completed += _ => { };
        if (request.error == null)
        {
            while (true)
            {
                if (request.downloadHandler.isDone)//是否读取完数据
                {
                    Debug.Log(request.downloadHandler.text);
                    return request.downloadHandler.text;
                }
            }
        }
        else
        {
            return null;
        }
    }


    public static T Load<T>(string prefabName) where T : Object
    {
        //prefabName --> prefabPath
        return Resources.Load<T>("");
    }
}