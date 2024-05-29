﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 释放器配置工厂
/// </summary>
public class DeployerConfigFactory : MonoBehaviour
{
    public static IAttackSelector CreateAttackSelector(SkillData skillData)
    {
        string className = skillData.selectorType + "AttackSelector";
        return CreateObject<IAttackSelector>(className);
    }

    private static T CreateObject<T>(string className) where T : class
    {
        Type type = Type.GetType(className);
        return Activator.CreateInstance(type) as T;
    }

}