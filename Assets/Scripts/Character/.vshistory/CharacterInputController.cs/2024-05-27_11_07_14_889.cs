using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInputController : MonoBehaviour
{
    public Button skill1;
    public Button skill2;
    public Button skill3;

    private void Start()
    {
        skill1.onClick.AddListener(() =>
        {

        });
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSkillButtonDown("1002");
        }
    }

    private void OnSkillButtonDown(string name)
    {
        CharacterSkillManager skillManager = GetComponent<CharacterSkillManager>();
        SkillData data = skillManager.PrepareSkill(int.Parse(name));
        if (data != null)
        {
            skillManager.GenerateSkill(data);
        }
    }
}
