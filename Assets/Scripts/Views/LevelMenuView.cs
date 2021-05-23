using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenuView : MonoBehaviour
{
    [SerializeField]
    private LevelCardView _levelCardPrefab;
    [SerializeField]
    private DetailedLevelInfoView _levelInfoViewPrefab;

    [SerializeField]
    private Transform _container;
    [SerializeField]
    private Transform _detailedLevelContainer;
    [SerializeField]
    private LevelManager _levelManager;

    [SerializeField]
    private LevelInfoLoader _levelInfoLoder;

    private void Start()
    {
        Initialize(_levelInfoLoder.LevelsInfo.levels);
    }

    public void Initialize(List<Level> levels)
    {
        foreach (var level in levels)
        {
            var levelCardView = Instantiate(_levelCardPrefab, _container);
            levelCardView.Initialize(level, _levelManager.LevelBackgroundSprite(level.name));
            levelCardView.OnClick += () => ShowDetailedLeaderInfo(level, _levelManager.LevelBackgroundSprite(level.name));
        }
    }

    private void ShowDetailedLeaderInfo(Level level, Sprite levelBackground)
    {
        DetailedLevelInfoView detailedInfoView = Instantiate(_levelInfoViewPrefab, _detailedLevelContainer);
        detailedInfoView.Initialize(level, levelBackground);
        detailedInfoView.OnPlay += () => _levelManager.LoadLevel(level);
    }
}
