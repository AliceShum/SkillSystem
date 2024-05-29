using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    private static GameObjectPool instance;
    public static GameObjectPool Instance()
    {
        instance = this;
    }

}
