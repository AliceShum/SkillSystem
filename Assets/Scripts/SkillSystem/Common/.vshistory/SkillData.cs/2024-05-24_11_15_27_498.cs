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
    public float atkInterval; //伤害间隔
    [HideInInspector]
    public GameObject owner; //技能所属

}
