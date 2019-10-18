using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class LevelManager : MonoBehaviour
{
    static CostumeManager costumeManager;

    public static List<BaseCostume> CostumeList { get { return costumeManager.costumeScripts; } }

    private void Awake()
    {
        costumeManager = (CostumeManager)AssetDatabase.LoadAssetAtPath("Assets/Scriptable Objects/Costume Manager.asset", typeof(CostumeManager));
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (BaseCostume costume in costumeManager.costumeScripts)
        {
            costume.currentMana = costume.maxMana;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void Reset()
    {
        SceneManager.LoadScene("TestScene");
    }
}
