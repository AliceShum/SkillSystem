using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SkillData
{
    public int skillID;
    public string name;
    public string description;
    public int coolTime;
    public int coolRemain; //冷却剩余
    public int costSP;//魔法消耗
    public float attackDistance;
    public float attackAngle;
    public string[] attackTargetTags = { "Enemy" };
    [HideInInspector]
    public Transform[] attackTargets; //攻击目标对象数组
    public string[] impactType = { "CostSP", "Damage" }; //技能影响类型
    public int nextBatterId; //连击的下一个技能编号
    public float atkRatio; //伤害比率
    public float durationTime; //持续时间
    public float atkInterval; //伤害间隔/攻击速度
    [HideInInspector]
    public GameObject owner; //技能所属
    public string prefabName; //技能预制件名称
    [HideInInspector]
    public GameObject skillPrefab;
    public string animationName;
    public string hitFxName; //受击特效名称
    [HideInInspector]
    public GameObject hitFxPrefab; //受击特效预制件
    public int level;
    public SkillAttackType attackType;// 攻击类型 单攻，群攻
    public SelectorType selectorType; //选择类型 扇形（圆形），矩形
}
