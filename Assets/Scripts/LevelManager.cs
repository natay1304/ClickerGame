using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LevelManager")]
public class LevelManager : ScriptableObject
{
    public string LevelName { get; private set; }
    public Sprite LevelBackground { get; private set; }
    public Sprite Cookie { get; private set; }

    public Level CurentLevel { get; private set; }

    [SerializeField]
    private List<LevelConfig> _levelConfigs;

    public void LoadLevel(Level level)
    {
        var config = _levelConfigs
            .Find(levelConfig => levelConfig.levelName == level.name);

        LevelName = config.levelName;
        LevelBackground = config.levelBackground;
        Cookie = config.cookie;

        CurentLevel = level;

        SceneManager.LoadScene("level");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public Sprite LevelBackgroundSprite(string levelName)
    {
        var config = _levelConfigs.Find(levelConfig => levelConfig.levelName == levelName);
        return config.levelBackground;
    }
}

[System.Serializable]
public class LevelConfig
{
    public string levelName;
    public Sprite levelBackground;
    public Sprite cookie;
}
