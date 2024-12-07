using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEditor.SceneTemplate;
using UnityEngine;

public class UIManager
{
    private static UIManager _instance;
    private Transform _uiRoot; // 最顶层的根选择了Canvas
    private Dictionary<string, string> pathDict; // 预制体路径
    private Dictionary<string, GameObject> prefabDict; // 预制体缓存字典
    public Dictionary<string, BasePanel> panelDict; // 已打开界面的缓存字典

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UIManager();
            }
            return _instance;
        }
    }

    public Transform UIRoot
    {
        get
        {
            if (_uiRoot == null)
            {
                _uiRoot = GameObject.Find("Canvas").transform; // 最顶层的
            }
            return _uiRoot;
        }
    }

    private UIManager()
    {
        InitDicts();
    }

    private void InitDicts()
    {
        prefabDict = new Dictionary<string, GameObject>();
        panelDict = new Dictionary<string, BasePanel>();
        pathDict = new Dictionary<string, string>()
        {
            { UIConst.MainPanel, "UIPanel/MainPanel" },
            { UIConst.MenuPanel, "UIPanel/MenuPanel" },
            { UIConst.UserPanel, "UIPanel/UserPanel" },
        };
    }
    
    // 打开界面
    public BasePanel OpenPanel(string name)
    {
        BasePanel panel = null;
        // 检查是否已经打开
        if (panelDict.TryGetValue(name, out panel))
        {
            Debug.LogError(name + " is already open");
            return null;
        }
        
        // 检查路径是否存在配置当中
        string path = "";
        if (!pathDict.TryGetValue(name, out path))
        {
            Debug.LogError(name + " is error, or still not setup the path");
            return null;
        }
        
        // 使用缓存的预制件
        GameObject panelPrefab = null;
        if (!prefabDict.TryGetValue(path, out panelPrefab)) // 没加载这个预制件
        {
            string realPath = "Prefabs/" + path;
            panelPrefab = Resources.Load<GameObject>(realPath) as GameObject;
            prefabDict.Add(name, panelPrefab);
        }
        
        GameObject panelObject = GameObject.Instantiate(panelPrefab, UIRoot, false);
        panel = panelObject.GetComponent<BasePanel>();
        panelDict.Add(name, panel);
        return panel;
    }

    public bool ClosePanel(string name)
    {
        BasePanel panel = null;
        if (!panelDict.TryGetValue(name, out panel))
        {
            Debug.LogError(name + " is not open");
            return false;
        }
        panel.ClosePanel();
        return true;
    }
}

public class UIConst
{
    public const string MainPanel = "MainPanel";
    
    public const string MenuPanel = "MenuPanel";
    
    public const string UserPanel = "UserPanel";
}
