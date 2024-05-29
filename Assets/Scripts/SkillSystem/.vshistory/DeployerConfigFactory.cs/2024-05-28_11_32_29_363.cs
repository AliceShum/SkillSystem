using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 释放器配置工厂:提供创建释放器各种算法对象的功能
/// 作用：将对象的创建 与 使用分离
/// </summary>
public class DeployerConfigFactory : MonoBehaviour
{
    public static IAttackSelector CreateAttackSelector(SkillData skillData)
    {
        string className = skillData.selectorType + "AttackSelector";
        return CreateObject<IAttackSelector>(className);
    }

    public static IImpactEffect[] CreateImpactEffects(SkillData skillData)
    {
        IImpactEffect[] impactArray = new IImpactEffect[skillData.impactType.Length];
        for (int i = 0; i < skillData.impactType.Length; i++)
        {
            IImpactEffect impactEffect = CreateObject<IImpactEffect>(skillData.impactType[i] + "Impact");
            impactArray[i] = impactEffect;
        }
        return impactArray;
    }

    private static T CreateObject<T>(string className) where T : class
    {
        Type type = Type.GetType(className);
        return Activator.CreateInstance(type) as T;
    }

}
