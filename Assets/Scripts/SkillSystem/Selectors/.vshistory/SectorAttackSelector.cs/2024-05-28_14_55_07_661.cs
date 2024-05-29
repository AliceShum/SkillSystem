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
            //targets.AddRange(tempGoArray.Select(g => g.transform));
        }

        //判断攻击范围
        targets = targets.FindAll(t =>
            Vector3.Distance(t.position, skillTF.position) <= data.attackDistance &&
            Vector3.Angle(skillTF.forward, t.position - skillTF.position) <= data.attackAngle * 0.5f
        );

        //筛选出活的角色
        targets.FindAll(t => t.GetComponent<CharacterStatus>().hp > 0);

        return targets.ToArray();
    }


    /*public Q[] Select<T, Q>(this T[] array, Func<T, Q> condition)
    {
        //储存筛选出来满足条件的元素
        Q[] result = new Q[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            //筛选的条件【满足筛选条件，就将该元素存到result】
            result[i] = condition(array[i]);
        }
        return result;
    }*/
}
