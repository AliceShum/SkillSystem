using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelected : MonoBehaviour
{
    public GameObject selectedGo;
    private void Start()
    {
        selectedGo = transform.Find("selected").gameObject;
    }

    public void SetSelectedActive(bool state)
    {

    }

}
