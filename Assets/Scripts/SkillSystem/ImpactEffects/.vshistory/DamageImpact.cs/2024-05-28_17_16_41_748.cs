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
        float atkTime = 0;

        //伤害目标生命
        do
        {
            yield return new WaitForSeconds(data.atkInterval);
            atkTime += data.atkInterval;
        } while (atkTime > 0); //攻击时间没到
    }

}
