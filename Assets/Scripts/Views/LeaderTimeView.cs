using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderTimeView : MonoBehaviour
{
    [SerializeField]
    private Text _leaderName;
    [SerializeField]
    private Text _leaderTime;

    public void Initialize(LeaderboardItem leaderboard)
    {
        _leaderName.text = leaderboard.name;
        _leaderTime.text = leaderboard.time.ToString();
    }
}