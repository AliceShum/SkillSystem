using System.Collections;
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

    private void InitSkill(SkillData data)
    {
        data.skillPrefab = Resources.Load<GameObject>("Skill/" + data.prefabName);
        if (!string.IsNullOrEmpty(data.hitFxName))
            data.hitFxPrefab = Resources.Load<GameObject>("Skill/" + data.hitFxName);
        data.owner = gameObject;
    }

    //生成技能
    public void GenerateSkill()
    {

    }


}
