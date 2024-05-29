﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
            AssetDatabase.GUIDToAssetPath(resFiles[i]);
    }
}
