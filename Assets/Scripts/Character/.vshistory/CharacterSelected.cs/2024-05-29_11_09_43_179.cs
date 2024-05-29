using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelected : MonoBehaviour
{
    private GameObject selectedGo;
    public string selectedName = "selected";
    private void Start()
    {
        selectedGo = transform.Find("selected").gameObject;
    }

    public void SetSelectedActive(bool state)
    {

    }

}
