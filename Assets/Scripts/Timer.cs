using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public event Action OnTimeOut;

	[SerializeField]
	private Text _timerText;
	[SerializeField]
	private string _format = "0"; 

	private float _currentTime;
	private bool _isTimeOut = false;
	private bool _isPaused = true;

	public bool IsTimeOut
	{
		get { return _isTimeOut; }
	}

	public float CurrentTime
    {
		get { return _currentTime; }
    }


	public void StartTimer(float time)
	{
		_currentTime = time;
		_isTimeOut = false;
		_isPaused = false;
		UpdateUI(_currentTime);
	}

	public void Pause(bool value)
	{
		_isPaused = value;
	}

	private void Update()
	{
		if (_isTimeOut || _isPaused)
			return;

		_currentTime = Mathf.Max(0, _currentTime - Time.deltaTime);

		if (_currentTime > 0)
		{
			UpdateUI(_currentTime);
		}
		else
		{
			_isTimeOut = true;
			OnTimeOut?.Invoke();
		}
	}

	private void UpdateUI(float time)
	{
		_timerText.text = time.ToString(_format);
	}

    public void SetActive(bool active)
    {
		gameObject.SetActive(active);
    }
}
