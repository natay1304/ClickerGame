using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanelView : MonoBehaviour
{
    [SerializeField]
    private Animator _settingsAnimator;
    [SerializeField]
    private Button _closeButton;

    private void Start()
    {
        _closeButton.onClick.AddListener(CloseSettingPanel);
    }

    private void OnEnable()
    {
        _settingsAnimator.SetBool("Close", false);
    }

    public void CloseSettingPanel()
    {
        _settingsAnimator.SetBool("Close", true);
        StartCoroutine(SetActivwDelayed(false, 1f));
    }

    private IEnumerator SetActivwDelayed(bool active, float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(active);
    }
}
