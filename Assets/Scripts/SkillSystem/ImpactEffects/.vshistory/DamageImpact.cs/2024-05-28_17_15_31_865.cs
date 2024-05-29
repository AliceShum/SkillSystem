using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageImpact : IImpactEffect
{
    private SkillData data;
    public void Execute(SkillDeployer deployer)
    {
        // deployer.SkillData.attackTargets
        data = deployer.SkillData;
    }

    private IEnumerator RepeatDamage()
    {
        //伤害目标生命
        yield return new WaitForSeconds();
    }

}
