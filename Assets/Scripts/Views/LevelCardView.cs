using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class LevelCardView : MonoBehaviour
{
    public event Action OnClick;

    [SerializeField]
    private Text _nameField;
    [SerializeField]
    private Image[] _starsImage;
    [SerializeField]
    private Button _leaderboardButton;
    [SerializeField]
    private Image _levelCardImage;

    [SerializeField]
    private DetailedLevelInfoView _levelInfoViewPrefab;
    [SerializeField]
    private Transform _container;

    private void Start()
    {
        _leaderboardButton.onClick.AddListener(LeaderInfo);
    }

    private void LeaderInfo()
    {
        if (OnClick != null)
            OnClick();
    }

    public void Initialize(Level level, Sprite sprite)
    {
        _nameField.text = level.name;
        _levelCardImage.sprite = sprite;
        for (int i = 0; i < level.stars; i++)
        {
            _starsImage[i].color = Color.yellow;
        }
    }
}
