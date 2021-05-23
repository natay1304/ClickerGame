using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResultsView : MonoBehaviour
{
    [SerializeField]
    private Text _levelName;

    [SerializeField]
    private LeaderTimeView _leaderTimeViewPref;
    [SerializeField]
    private Transform _container;

    [SerializeField]
    private Button _backToMenu;
    [SerializeField]
    private LevelManager _levelManager;

    private void Start()
    {
        _backToMenu.onClick.AddListener(BackToMenuHandler);
    }

    private void BackToMenuHandler()
    {
        _levelManager.LoadMenu();
    }

    public void Initialize(Level level)
    {
        _levelName.text = level.name;

        foreach (var leaderInfo in level.leaderboard)
        {
            var leaderTimeView = Instantiate(_leaderTimeViewPref, _container);
            leaderTimeView.Initialize(leaderInfo);
        }
    }
}
