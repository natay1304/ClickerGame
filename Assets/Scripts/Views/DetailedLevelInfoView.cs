using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailedLevelInfoView : MonoBehaviour
{

    public event Action OnPlay;
    [SerializeField]
    private Image[] _starsImage;
    [SerializeField]
    private Text _levelName;

    [SerializeField]
    private LeaderTimeView _leaderTimeViewPref;
    [SerializeField]
    private Transform _container;
    [SerializeField]
    private Image _levelCardImage;

    [SerializeField]
    private Button _closeButton;
    [SerializeField]
    private Button _playButton;

    private void Start()
    {
        _closeButton.onClick.AddListener(CloseLevelDetails);
        _playButton.onClick.AddListener(PlayButtonHandler);
    }

    private void PlayButtonHandler()
    {
        OnPlay?.Invoke();
    }

    private void CloseLevelDetails()
    {
        Destroy(gameObject);
    }

    public void Initialize(Level level, Sprite levelBackground)
    {
        _levelName.text = level.name;
        _levelCardImage.sprite = levelBackground;
        Debug.Log(levelBackground.name);
        for (int i = 0; i < level.stars; i++)
        {
            _starsImage[i].color = Color.yellow;
        }

        foreach (var leaderInfo in level.leaderboard)
        {
            var leaderTimeView = Instantiate(_leaderTimeViewPref, _container);
            leaderTimeView.Initialize(leaderInfo);
        }
    }
}
