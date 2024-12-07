using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PackageTable", menuName = "Bag/Package Table")]
public class PackageTable : ScriptableObject
{
    public List<PackageTableItem> dataList = new List<PackageTableItem>();
}

[System.Serializable]
public class PackageTableItem
{
    public string id;

    public int type;

    public int star;

    public string name;
    
    public string description;
    
    public string skillDescription;

    public string imagePath;

    public int num;
}
