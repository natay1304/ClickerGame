using System;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
	public event Action<bool> OnValueChanged;
	public bool IsOn
	{
		get { return _toggle.isOn; }
	}

	[SerializeField]
	private Toggle _toggle;
	[SerializeField]
	private Animator _animator;

	private readonly int _isOnHash = Animator.StringToHash("IsOn");

	public void Awake()
	{
		_toggle.onValueChanged.AddListener(OnValueChangedHandler);
	}

    private void OnEnable()
    {
		_animator.SetBool(_isOnHash, IsOn);
	}

    private void OnValueChangedHandler(bool value)
	{
		_animator.SetBool(_isOnHash, value);
		OnValueChanged?.Invoke(value);
	}

	private void OnDestroy()
	{
		_toggle.onValueChanged.RemoveListener(OnValueChangedHandler);
	}

	public void SetValue(bool value)
    {
		//_toggle.isOn = value;
		_toggle.SetIsOnWithoutNotify(value);
	}
}
