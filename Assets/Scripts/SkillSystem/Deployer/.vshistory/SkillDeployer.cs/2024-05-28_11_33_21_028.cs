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
        selector = DeployerConfigFactory.CreateAttackSelector(SkillData);

        //影响
        impactArray = DeployerConfigFactory.CreateImpactEffects(SkillData);
    }

    //执行算法对象

    //释放方式

}
