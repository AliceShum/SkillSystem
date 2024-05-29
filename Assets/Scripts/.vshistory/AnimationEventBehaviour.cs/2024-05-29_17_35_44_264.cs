﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventBehaviour : MonoBehaviour
{
    public event Action attackHandler;

    public void OnAnimationStop(string name)
    {

    }

    public void TriggerEvent()
    {
        if (attackHandler != null)
            attackHandler();
    }
}