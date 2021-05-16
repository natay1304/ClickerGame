using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
	[SerializeField]
	private int _levelTime;

	[SerializeField]
	private Timer _timer;

	IEnumerator Start()
	{
		_timer.OnTimeOut += OnTimeOutHandler;

		yield return new WaitForSeconds(3f);

		// Start game...
		_timer.Start(_levelTime);
	}

	private void OnTimeOutHandler()
	{
		throw new System.NotImplementedException();
	}

	private void OnDestroy()
	{
		_timer.OnTimeOut -= OnTimeOutHandler;
	}
}
