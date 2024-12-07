using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }
    
    private PackageTable packageTable;
    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        UIManager.Instance.OpenPanel(UIConst.MainPanel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PackageTable GetPackageTable()
    {
        if (packageTable == null)
        {
            packageTable = Resources.Load<PackageTable>("PackageData/PackageTable");
        }
        return packageTable;
    }

    public List<PackageLocalItem> GetPackageLocalData()
    {
        return PackageLocalData.Instance.LoadPackage();
    }
}
