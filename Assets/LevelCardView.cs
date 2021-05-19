using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelCardView : MonoBehaviour
{
    //дописать поля
    [SerializeField]
    private Text _nameField;
    [SerializeField]
    private Image[] _starsImage;
    [SerializeField]
    private Button _leaderPanelButton;


    public void Initialize(Level level)
    {
        _nameField.text = level.name;
        for (int i = 0; i < level.stars; i++)
        {
            _starsImage[i].color = Color.yellow;
        }
    }
}
