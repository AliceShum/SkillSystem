using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInputController : MonoBehaviour
{
    private CharacterSkillController characterSkillController;

    public MyButton skill1;
    public Button skill2;
    public Button skill3;

    private void Start()
    {
        characterSkillController = GetComponent<CharacterSkillController>();
        /*skill1.onClick.AddListener(() =>
        {
            OnSkillButtonDown(skill1.name);
        });*/
        skill1.OnLongPress.AddListener(() =>
        {

        });
        skill2.onClick.AddListener(() =>
        {
            OnSkillButtonDown(skill2.name);
        });
        skill3.onClick.AddListener(() =>
        {
            OnSkillButtonDown(skill3.name);
        });
    }


    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSkillButtonDown("1002");
        }
    }*/

    private void OnSkillButtonDown(string name)
    {
        characterSkillController.AttackUseSkill(int.Parse(name));

        /*CharacterSkillManager skillManager = GetComponent<CharacterSkillManager>();
        SkillData data = skillManager.PrepareSkill(int.Parse(name));
        if (data != null)
        {
            skillManager.GenerateSkill(data);
        }*/
    }
}
