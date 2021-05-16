using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Text _timerText;

    public int maxTime = 30;
    private float _currentTime;
    private static bool _gameOver;
    public static bool GameOver
    {
        get { return _gameOver; }
    }


    private void Start()
    {
        _currentTime = maxTime;
        _timerText.text = maxTime.ToString();
    }

    private void Update()
    {
        if (_currentTime > 0)
        {
            _currentTime -= 1 * Time.deltaTime;
            _timerText.text = _currentTime.ToString("0") + " sec";
        }
        else
        {
            _gameOver = true;
        }
    }

    IEnumerator TimerCoroutine()
    {
        if (_currentTime > 0)
        {
            _currentTime -= 1 * Time.deltaTime;
            _timerText.text = _currentTime.ToString("0") + " sec";
        }
        yield return new WaitForSeconds(1f);
    }

}
