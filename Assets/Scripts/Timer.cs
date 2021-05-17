using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public event Action OnTimeOut;

	[SerializeField]
	private Text _timerText;

	private float _currentTime;
	private bool _isTimeOut = false;
	private bool _isPaused = false;

	public bool IsTimeOut
	{
		get { return _isTimeOut; }
	}


	public void Start(float time)
	{
		_currentTime = time;
		_isTimeOut = false;
		UpdateUI(_currentTime);
	}

	public void Pause()
	{
		_isPaused = false;
	}

	public void Resume()
	{
		_isPaused = true;
	}

	//public void Stop()
	//{
	//	throw new System.NotImplementedException();
	//}

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
		_timerText.text = time.ToString("0") + " sec";
	}
}
