using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSpeed : SingletonBase<DebugSpeed>
{
    [SerializeField] private float speedTime;
    void Start()
    {
        Time.timeScale = speedTime;
    }
}
