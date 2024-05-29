using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterSkillManager))]
/// <summary>
/// 封装技能系统，提供简单的技能释放功能
/// </summary>
public class CharacterSkillController : MonoBehaviour
{
    private CharacterSkillManager skillManager;
    private Animator anim;

    private SkillData skill;

    private void Start()
    {
        skillManager = GetComponent<CharacterSkillManager>();
        anim = GetComponent<Animator>();
        GetComponent<AnimationEventBehaviour>().attackHandler += DeploySkill;
    }

    private void DeploySkill()
    {
        //生成技能
        skillManager.GenerateSkill(skill);
    }

    /// <summary>
    /// 使用某个技能(玩家)
    /// </summary>
    public void AttackUseSkill(int skillID)
    {
        //准备技能
        skill = skillManager.PrepareSkill(skillID);
        if (skill == null) return;
        //播放动画
        anim.Play(skill.animationName);

        //如果单攻
        //--查找目标
        Transform targetTF = SelectTarget();
        //--朝向目标/向目标移动
        transform.LookAt(targetTF);
        //--选中目标
        //  1.选中目标，间隔指定时间后取消选中
        //  2.选中A目标，在自动取消前，又选中B目标，需要自动将A取消

    }

    private Transform SelectTarget()
    {
        Transform[] targets = new SectorAttackSelector().SelectTarget(skill, transform);
        if (targets.Length == 0)
            return null;
        return targets[0];
    }

    private void SsetSelectedActiveFx(bool state)
    {

    }

    /// <summary>
    /// 使用随机技能(NPC)
    /// </summary>
    public void UseRandomSkill()
    {
        //需求：从 管理器 中挑选出随机的技能
        //--先筛选出所有可以释放的技能，在产生随机数
        List<SkillData> usableSkills = new List<SkillData>();
        foreach (SkillData data in skillManager.skills)
        {
            if (skillManager.PrepareSkill(data.skillID) != null)
                usableSkills.Add(data);
        }
        if (usableSkills.Count == 0) return;
        int index = UnityEngine.Random.Range(0, usableSkills.Count);
        AttackUseSkill(usableSkills[index].skillID);
    }

}
