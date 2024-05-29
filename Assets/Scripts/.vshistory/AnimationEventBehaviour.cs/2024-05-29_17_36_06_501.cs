using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventBehaviour : MonoBehaviour
{
    private Animator anim;
    public event Action attackHandler;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnAnimationStop(string name)
    {

    }

    public void TriggerEvent()
    {
        if (attackHandler != null)
            attackHandler();
    }
}
