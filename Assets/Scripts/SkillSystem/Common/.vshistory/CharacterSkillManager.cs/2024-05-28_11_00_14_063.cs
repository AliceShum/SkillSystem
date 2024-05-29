using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 技能管理器
/// </summary>
public class CharacterSkillManager : MonoBehaviour
{
    //技能列表
    public SkillData[] skills;

    private void Start()
    {
        for (int i = 0; i < skills.Length; i++)
        {
            InitSkill(skills[i]);
        }
    }

    //初始化技能
    private void InitSkill(SkillData data)
    {
        data.skillPrefab = ResourceManager.Load<GameObject>(data.prefabName);
        if (!string.IsNullOrEmpty(data.hitFxName))
            data.hitFxPrefab = ResourceManager.Load<GameObject>(data.hitFxName);
        data.owner = gameObject;
    }

    //技能释放条件：冷却 法力
    public SkillData PrepareSkill(int id)
    {
        //根据id查找技能数据
        SkillData data = Find(s => s.skillID == id);
        //判断条件
        float sp = GetComponent<CharacterStatus>().sp;
        if (data != null && data.coolRemain <= 0 && data.costSP <= sp)
        {
            return data;
        }
        //返回技能数据
        return null;
    }

    //生成技能
    public void GenerateSkill(SkillData data)
    {
        //创建
        //GameObject skillGo = Instantiate(data.skillPrefab, transform.position, transform.rotation);
        GameObject skillGo = GameObjectPool.Instance().CreateObject(data.prefabName, data.skillPrefab, transform.position, transform.rotation);

        //传递技能数据
        SkillDeployer deployer = skillGo.GetComponent<SkillDeployer>();
        deployer.SkillData = data;

        //销毁
        //Destroy(skillGo, data.durationTime);
        GameObjectPool.Instance().CollectObject(skillGo, data.durationTime);

        //开启技能冷却
        StartCoroutine(CoolTimeDown(data));
    }

    private IEnumerator CoolTimeDown(SkillData data)
    {
        data.coolRemain = data.coolTime;
        while (data.coolRemain > 0)
        {
            yield return new WaitForSeconds(1f);
            data.coolRemain--;
        }
    }


    //放去工具类？
    private SkillData Find(int id)
    {
        foreach (SkillData sd in skills)
        {
            if (sd.skillID == id)
                return sd;
        }
        return null;
    }
    //Func<SkillData, bool>  参数是SkillData，返回值是bool。委托。跟上面方法一样
    private SkillData Find(Func<SkillData, bool> handler)
    {
        foreach (SkillData sd in skills)
        {
            //if (sd.skillID == id)
            if (handler(sd))
                return sd;
        }
        return null;
    }
}
