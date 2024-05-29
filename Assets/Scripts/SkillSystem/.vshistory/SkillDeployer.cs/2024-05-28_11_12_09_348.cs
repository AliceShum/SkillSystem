﻿using System;
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

    //初始化
    private void InitDeployer()
    {
        //创建算法对象(反射)
        Type type = Type.GetType(SkillData.selectorType + "AttackSelector");
        IAttackSelector selector = Activator.CreateInstance(type) as IAttackSelector;

        //选区

        //影响

    }

    //执行算法对象

    //释放方式

}