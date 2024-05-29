using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 扇形/圆形选区
/// </summary>
public class SectorAttackSelector : IAttackSelector
{
    public Transform[] SelectTarget(SkillData data, Transform skillTF)
    {
        //根据技能数据中的标签，获取所有目标
        List<Transform> targets = new List<Transform>();
        for (int i = 0; i < data.attackTargetTags.Length; i++)
        {
            GameObject[] tempGoArray = GameObject.FindGameObjectsWithTag(data.attackTargetTags[i]);
            for (int j = 0; j < tempGoArray.Length; j++)
                targets.Add(tempGoArray[j].transform);
        }

        //判断攻击范围


        //筛选出活的角色

    }

}
