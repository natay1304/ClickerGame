using UnityEngine;
using System;
using System.IO;

[CreateAssetMenu]
public class LevelInfoLoader : ScriptableObject
{
    private string path => Application.streamingAssetsPath + "/Info.json";
    [NonSerialized]
    private LevelsInfo _levelInfo = null;

    public LevelsInfo LevelsInfo
    {
        get
        {
            if (_levelInfo == null)
                _levelInfo = JsonUtility.FromJson<LevelsInfo>(File.ReadAllText(path));

            return _levelInfo;
        }
    }

    public void AddPlayerResult(string userName, float time, string levelName)
    {

        var level = _levelInfo.levels
            .Find(a => a.name == levelName);

        var leaderboard = level.leaderboard;
        for (int i = 0; i < leaderboard.Count; )
        {
            if(userName == leaderboard[i].name)
            {
                leaderboard.RemoveAt(i);
                continue;
            }
            i++;
        }

        int index = 0;
        for (int i = 0; i < leaderboard.Count; i++, index++)
        {
            if (leaderboard[i].time > time)
                break;
        }

        var userResult = new LeaderboardItem() { name = userName, time = time };
        leaderboard.Insert(index, userResult);

        string newPlayerResults = JsonUtility.ToJson(_levelInfo);
        File.WriteAllText(path, newPlayerResults);
    }
}
