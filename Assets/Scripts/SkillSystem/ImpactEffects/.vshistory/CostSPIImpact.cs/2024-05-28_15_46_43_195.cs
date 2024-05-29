using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostSPIImpact : IImpactEffect
{
    public void Execute(SkillDeployer deployer)
    {
        var status = deployer.SkillData.owner.GetComponent<CharacterStatus>();

    }
}
