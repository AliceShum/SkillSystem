﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageImpact : IImpactEffect
{
    public void Execute(SkillDeployer deployer)
    {
        // deployer.SkillData.attackTargets

    }

    private IEnumerator RepeatDamage()
    {
        //伤害目标生命
        yield return new WaitForSeconds();
    }

}