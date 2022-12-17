using System;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
      
    }
    
    public int level2Save, level3Save, level4Save, level5Save, level6Save; 
    public void LevelCompletedSave(int levelNumber)
    {
        switch (levelNumber)
        {
            case 2 :
                level2Save = 1;
                PlayerPrefs.SetInt(nameof(level2Save),1);
                break;
            case 3:
                level3Save = 1;
                PlayerPrefs.SetInt(nameof(level3Save),1);
                break;
            case 4 :
                level4Save = 1;
                PlayerPrefs.SetInt(nameof(level4Save),1);
                break;
            case 5:
                level5Save = 1;
                PlayerPrefs.SetInt(nameof(level5Save),1);
                break;
            case 6:
                level6Save = 1;
                PlayerPrefs.SetInt(nameof(level6Save),1);
                break;
            default:
                break;
        }
        
        
    }

    public void LoadSave()
    {
        level2Save = PlayerPrefs.GetInt(nameof(level2Save));
        level3Save = PlayerPrefs.GetInt(nameof(level3Save));
        level4Save = PlayerPrefs.GetInt(nameof(level4Save));
        level5Save = PlayerPrefs.GetInt(nameof(level5Save));
        level6Save = PlayerPrefs.GetInt(nameof(level6Save));
    }
}
