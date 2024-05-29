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

    private IAttackSelector selector;
    private List<IImpactEffect> impactEffects;

    //初始化
    private void InitDeployer()
    {
        //选区(反射)  获取类型，生成实例
        Type type = Type.GetType(SkillData.selectorType + "AttackSelector");
        selector = Activator.CreateInstance(type) as IAttackSelector;

        //影响
        for (int i = 0; i < skillData.impactType.Length; i++)
        {
            type = Type.GetType(skillData.impactType[i] + "Impact");
            IImpactEffect impactEffect = Activator.CreateInstance(type) as IImpactEffect;
            impactEffects.Add(impactEffect);
        }
    }

    //执行算法对象

    //释放方式

}
