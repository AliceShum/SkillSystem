using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 封装技能系统，提供简单的技能释放功能
/// </summary>
public class CharacterSkillController : MonoBehaviour
{
    private CharacterSkillManager skillManager;

    private void Start()
    {

    }

    /// <summary>
    /// 使用某个技能(玩家)
    /// </summary>
    public void AttackUseSkill()
    {
        //准备技能

        //播放动画

        //生成技能

        //如果单攻 --朝向目标/向目标移动； --选中目标

    }

    /// <summary>
    /// 使用随机技能(NPC)
    /// </summary>
    public void UseRandomSkill()
    {
        //需求：从 管理器 中挑选出随机的技能
        //--先筛选出所有可以释放的技能，在产生随机数

    }

}
