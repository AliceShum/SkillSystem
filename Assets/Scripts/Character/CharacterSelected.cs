using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelected : MonoBehaviour
{
    private GameObject selectedGo;
    [Tooltip("选择器名称")]
    public string selectedName = "";
    [Tooltip("显示时间")]
    public float displayTime = 3;
    private float hideTime;

    private void Start()
    {
        selectedGo = transform.Find(selectedName).gameObject;
    }

    public void SetSelectedActive(bool state)
    {
        selectedGo.SetActive(state);
        this.enabled = state; //开启/停止update调用
        if (state)
            hideTime = Time.time + displayTime;
    }

    private void Update()
    {
        if (hideTime <= Time.time)
        {
            SetSelectedActive(false);
        }
    }
}
