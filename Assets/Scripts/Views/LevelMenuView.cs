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



    public void Initialize(Level[] levels)
    {
        int i = 0;
        foreach (var level in levels)
        {
            var levelCardView = Instantiate(_levelCardPrefab, _container);
            levelCardView.Initialize(level, _levelManager.LevelBackgroundSprite(level.name));
            levelCardView.OnClick += () => ShowDetailedLeaderInfo(level);
            i++;
        }
    }

    private void ShowDetailedLeaderInfo(Level level)
    {
        DetailedLevelInfoView detailedInfoView = Instantiate(_levelInfoViewPrefab, _detailedLevelContainer);
        detailedInfoView.Initialize(level);
        detailedInfoView.OnPlay += () => _levelManager.LoadLevel(level);
    }
}
