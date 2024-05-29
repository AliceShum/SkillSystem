using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageImpact : IImpactEffect
{
    private SkillData data;
    public void Execute(SkillDeployer deployer)
    {
        data = deployer.SkillData;
        deployer.StartCoroutine(RepeatDamage());
    }

    private IEnumerator RepeatDamage()
    {
        float atkTime = 0;
        do
        {
            //伤害目标生命  deployer.SkillData.attackTargets
            yield return new WaitForSeconds(data.atkInterval);
            atkTime += data.atkInterval;
        } while (atkTime < data.durationTime); //攻击时间没到
    }

}
