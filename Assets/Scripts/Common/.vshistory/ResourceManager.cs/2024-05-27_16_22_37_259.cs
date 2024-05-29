using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class ResourceManager
{
    private static Dictionary<string, string> configMap;

    //作用：初始化类的静态数据成员
    //时机：类被加载时执行一次
    static ResourceManager()
    {
        //加载文件
        string fileContent = GetConfigFile("ConfigMap.txt");
        //解析文件（string --> Dictionary<string, string>  prefabName --> prefabPath）
        BuildMap(fileContent);
    }

    public static string GetConfigFile(string fileName)
    {
        //string url = Application.streamingAssetsPath + "/ConfigMap.txt";

        string url;
#if UNITY_EDITOR
        url = "file://" + Application.dataPath + "/StreamingAssets/" + fileName;
#elif UNITY_IPHONE
    URL = "file://" + Application.dataPath + "/Raw/" + fileName;
#elif UNITY_ANDROID
    URL = "jar:file://" + Application.dataPath + "!/assets/" + fileName;
#endif

        UnityWebRequest request = UnityWebRequest.Get(url);
        var operation = request.SendWebRequest();
        //operation.completed += _ => { };
        if (request.error == null)
        {
            while (true)
            {
                if (request.downloadHandler.isDone)//是否读取完数据
                {
                    //Debug.Log(request.downloadHandler.text);
                    return request.downloadHandler.text;
                }
            }
        }
        else
        {
            return null;
        }
    }

    public static void BuildMap(string fileContent)
    {
        configMap = new Dictionary<string, string>();
        //StringReader字符串读取器，提供了逐行读取字符串的功能
        using (StringReader reader = new StringReader(fileContent))
        {
            while ((line = reader.ReadLine()) != null)
            {
                //解析行代码
                string[] keyValue = line.Split("=");
                configMap.Add(keyValue[0], keyValue[1]);
            }

            /*string line = reader.ReadLine();
            while (line != null)
            {
                string[] keyValue = line.Split("=");
                configMap.Add(keyValue[0], keyValue[1]);
                line = reader.ReadLine();
            }*/
        } //当程序退出using代码块，将自动调用reader.Dispose()方法
    }

    public static T Load<T>(string prefabName) where T : Object
    {
        //prefabName --> prefabPath
        string prefabPath = configMap[prefabName];
        return Resources.Load<T>(prefabPath);
    }
}
