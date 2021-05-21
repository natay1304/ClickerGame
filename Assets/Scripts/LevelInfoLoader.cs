using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelInfoLoader : MonoBehaviour
{
    [SerializeField]
    private LevelMenuView _levelMenuView;
    private string path;
    private string jsonString;

    private void Start()
    {
        path = Application.streamingAssetsPath + "/Info.json";
        jsonString = File.ReadAllText(path);

        LevelsInfo levelInfo = JsonUtility.FromJson<LevelsInfo>(jsonString);

        _levelMenuView.Initialize(levelInfo.levels);
    }

    public void AddNewPlayerResult(LevelsInfo newResults)
    {
        string newPlayerResults = JsonUtility.ToJson(newResults);
        File.WriteAllText(path, newPlayerResults);
    }

}
