using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSkillButtonDown（）；
        }
    }

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
