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

    /// <summary>
    /// 如果按了技能A，连着按技能B，那么因为成员变量skill只有一个，会引发bug:新按的技能B动作会执行2次
    /// 解决：1.把skill弄成一个队列，保存每次按下的技能操作，按顺序执行（DeploySkill拿出最前的技能，执行完在队列删除）。
    ///       2.在当前技能没执行完之前，把其他技能当作无效操作（ARPG通常做法）
    ///       王者荣耀上面2个都采用：动作队列只会保存两个，其他的忘记
    /// </summary>
    private SkillData skill;

    public Transform selectedTarget; //选中的目标

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
    public void AttackUseSkill(int skillID, bool isBatter = false)
    {
        if (skill != null && isBatter) //连击
            skillID = skill.nextBatterId;
        //准备技能
        skill = skillManager.PrepareSkill(skillID);
        if (skill == null) return;
        //播放动画
        anim.Play(skill.animationName);

        //如果单攻
        if (skill.attackType != SkillAttackType.Single) return;
        //--查找目标
        Transform targetTF = SelectTarget();
        //--朝向目标/向目标移动
        transform.LookAt(targetTF);
        //--选中目标
        //  1.选中目标，间隔指定时间后取消选中
        //  2.选中A目标，在自动取消前，又选中B目标，需要自动将A取消
        SsetSelectedActiveFx(false); //取消上次选中的物体
        selectedTarget = targetTF;
        SsetSelectedActiveFx(true); //选中当前的物体
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
        if (selectedTarget == null)
            return;
        var selected = selectedTarget.GetComponent<CharacterSelected>();
        if (selected) selected.SetSelectedActive(state);
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
