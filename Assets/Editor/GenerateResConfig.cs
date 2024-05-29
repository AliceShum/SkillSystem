using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

/// <summary>
/// 生成配置文件类
/// </summary>
public class GenerateResConfig : Editor
{
    [MenuItem("Tools/Resources/Generate ResConfig File")]
    public static void Generate()
    {
        //生成资源配置文件
        //1.查找Resources目录下所有预制件完整路径
        //2.生成对应关系
        //   名称=路径
        //3.写入文件
        string[] resFiles = AssetDatabase.FindAssets("t:prefab", new string[] { "Assets/Resources" });
        for (int i = 0; i < resFiles.Length; i++)
        {
            resFiles[i] = AssetDatabase.GUIDToAssetPath(resFiles[i]);
            string fileName = Path.GetFileNameWithoutExtension(resFiles[i]);
            string filePath = resFiles[i].Replace("Assets/Resources/", string.Empty).Replace(".prefab", string.Empty);
            resFiles[i] = fileName + "=" + filePath;
            //Debug.Log(resFiles[i]);
        }
        File.WriteAllLines("Assets/StreamingAssets/ConfigMap.txt", resFiles);
        AssetDatabase.Refresh();
    }
}
