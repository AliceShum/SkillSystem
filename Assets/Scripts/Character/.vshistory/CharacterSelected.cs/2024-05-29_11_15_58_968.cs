using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelected : MonoBehaviour
{
    private GameObject selectedGo;
    public string selectedName = "";
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
