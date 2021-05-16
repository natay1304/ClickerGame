using System;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
	public bool IsOn
	{
		get { return _toggle.isOn; }
	}

	[SerializeField]
	private Toggle _toggle;
	[SerializeField]
	private Animator _animator;

	private readonly int _isOnHash = Animator.StringToHash("IsOn");

	public void Start()
	{
		SetState(_toggle.isOn);
		_toggle.onValueChanged.AddListener(SetState);
	}

	private void SetState(bool value)
	{
		_animator.SetBool(_isOnHash, value);
	}

	private void OnDestroy()
	{
		_toggle.onValueChanged.RemoveListener(SetState);
	}
}
