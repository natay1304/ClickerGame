using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Clickable : MonoBehaviour, IPointerClickHandler
{
    public event Action OnClick;
    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick?.Invoke();
    }

    public void SetPosition(Vector2 newPos)
    {
        _transform.transform.position = (Vector3)newPos;
    }
}
