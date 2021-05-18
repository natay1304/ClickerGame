using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Clickable : MonoBehaviour, IPointerClickHandler
{
    public event Action OnClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick?.Invoke();
    }

    public void SetPosition(Vector2 newPos)
    {
        transform.position = (Vector3)newPos;
    }

    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }
}
