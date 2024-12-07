using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackagePanel : BasePanel
{
    private Transform UIUp;
    private Transform UIDown;
    private Transform UILeft;
    private Transform UIRight;

    protected void Awake()
    {
        InitUI();
    }

    private void InitUI()
    {
        InitUIName();
    }

    private void InitUIName()
    {
        UIUp = transform.Find("Up");
        UIDown = transform.Find("Down");
        UILeft = transform.Find("Left");
        UIRight = transform.Find("Right");
        
    }
}
