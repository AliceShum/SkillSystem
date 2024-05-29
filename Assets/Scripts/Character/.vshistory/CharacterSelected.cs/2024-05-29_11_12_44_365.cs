using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelected : MonoBehaviour
{
    private GameObject selectedGo;
    public string selectedName = "";

    private float hideTime;

    private void Start()
    {
        selectedGo = transform.Find(selectedName).gameObject;
    }

    public void SetSelectedActive(bool state)
    {
        selectedGo.SetActive(state);
        this.enabled = state;
        if (state)
            hideTime = Time.time + 3;
    }

    private void Update()
    {
        if (hideTime <= Time.time)
        {
            SetSelectedActive(false);
        }
    }
}
