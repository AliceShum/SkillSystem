using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDeployer : MonoBehaviour
{
    private SkillData skillData;
    public SkillData SkillData
    {
        get { return SkillData; }
        set
        {
            skillData = value;
            InitDeployer();
        }
    }

    private IAttackSelector selector; //选取算法对象
    private IImpactEffect[] impactArray; //影响效果对象

    //初始化
    private void InitDeployer()
    {
        //选区(反射)  获取类型，生成实例
        selector = CreateObject<IAttackSelector>(SkillData.selectorType + "AttackSelector");

        //影响
        for (int i = 0; i < skillData.impactType.Length; i++)
        {
            type = Type.GetType(skillData.impactType[i] + "Impact");
            IImpactEffect impactEffect = Activator.CreateInstance(type) as IImpactEffect;
            impactEffects.Add(impactEffect);
        }
    }

    private T CreateObject<T>(string className) where T : Type
    {
        Type type = Type.GetType(className);
        return Activator.CreateInstance(type) as T;
    }

    //执行算法对象

    //释放方式

}
