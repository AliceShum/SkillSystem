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
}
