using System.Collections;
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

    }

    IEnumerator GetDataB(string fileName)
    {
        //1.url地址
        string fromPath = Application.streamingAssetsPath + "/" + fileName;
        //2.创建一个UnityWebRequest类 method属性为Get
        UnityWebRequest request = UnityWebRequest.Get(fromPath);
        //3.等待响应时间，超过5秒结束
        request.timeout = 5;
        //4.发送请求信息
        yield return request.SendWebRequest();

        //5.判断是否下载完成
        if (request.isDone)
        {
            //6.判断是否下载错误
            if (request.isHttpError || request.isNetworkError)
                Debug.Log(request.error);
            else
                Debug.Log(request.downloadHandler.text);
        }
    }


    public static T Load<T>(string prefabName) where T : Object
    {
        //prefabName --> prefabPath
        return Resources.Load<T>("");
    }
}
