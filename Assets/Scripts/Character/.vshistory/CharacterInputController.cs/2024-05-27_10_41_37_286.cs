using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputController : MonoBehaviour
{
    public void OnSkillButtonDown()
    {
        CharacterSkillManager skillManager = GetComponent<CharacterSkillManager>();
        SkillData data = skillManager.PrepareSkill(1002);
        if (data != null)
        {
            skillManager.GenerateSkill(data);
        }
    }
}
