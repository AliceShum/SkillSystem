﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 技能管理器
/// </summary>
public class CharacterSkillManager : MonoBehaviour
{
    //技能列表
    public SkillData[] skills;

    private void Start()
    {
        for (int i = 0; i < skills.Length; i++)
        {
            InitSkill(skills[i]);
        }
    }

    //初始化技能
    private void InitSkill(SkillData data)
    {
        data.skillPrefab = Resources.Load<GameObject>("Skill/" + data.prefabName);
        if (!string.IsNullOrEmpty(data.hitFxName))
            data.hitFxPrefab = Resources.Load<GameObject>("Skill/" + data.hitFxName);
        data.owner = gameObject;
    }

    //技能释放条件：冷却 法力
    public SkillData PrepareSkill(int id)
    {
        //根据id查找技能数据
        SkillData data = null;
        foreach (SkillData sd in skills)
        {
            if (sd.skillID == id)
                data = sd;
        }

        //判断条件

        //返回技能数据

    }

    //生成技能
    public void GenerateSkill(SkillData data)
    {
        //创建
        GameObject skillGo = Instantiate(data.skillPrefab, transform.position, transform.rotation);

        //销毁
        Destroy(skillGo, data.durationTime);

        //开启技能冷却
        StartCoroutine(CoolTimeDown(data));
    }

    private IEnumerator CoolTimeDown(SkillData data)
    {
        data.coolRemain = data.coolTime;
        while (data.coolRemain > 0)
        {
            yield return new WaitForSeconds(1f);
            data.coolRemain--;
        }
    }


    //工具类
    private SkillData Find(int id)
    {
        foreach (SkillData sd in skills)
        {
            if (sd.skillID == id)
                return sd;
        }
    }
}