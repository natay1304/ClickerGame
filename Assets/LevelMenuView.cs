using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuView : MonoBehaviour
{
    [SerializeField]
    private LevelCardView _levelCardPrefab;
    [SerializeField]
    private Transform _container;

    public void Initialized(Level[] levels)
    {
        foreach (var level in levels)
        {
            var levelCard = Instantiate(_levelCardPrefab, _container);
            levelCard.Initialize(level);
        }
    }
}
