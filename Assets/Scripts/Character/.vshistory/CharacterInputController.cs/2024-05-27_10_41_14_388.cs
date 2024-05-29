using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputController : MonoBehaviour
{
    public void OnSkillButtonDown()
    {
        SkillData data = GetComponent<CharacterSkillManager>().PrepareSkill(1002);
        if (data != null)
        {
            GetComponent<CharacterSkillManager>().GenerateSkill(data);
        }
    }
}
