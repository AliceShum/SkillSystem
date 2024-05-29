using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageImpact : IImpactEffect
{
    private SkillData data;
    public void Execute(SkillDeployer deployer)
    {
        data = deployer.SkillData;
        deployer.StartCoroutine(RepeatDamage(deployer));
    }

    //重复伤害
    private IEnumerator RepeatDamage(SkillDeployer deployer)
    {
        float atkTime = 0;
        do
        {
            OnceDamage(); //伤害目标生命  
            yield return new WaitForSeconds(data.atkInterval);
            atkTime += data.atkInterval;
            deployer.CalculateTargets();
        } while (atkTime < data.durationTime); //攻击时间没到
    }

    private void OnceDamage()
    {
        for (int i = 0; i < data.attackTargets; i++)
        {

        }
    }

}
