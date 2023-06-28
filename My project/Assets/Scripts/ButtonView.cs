using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ButtonView : MonoBehaviour
{
    public Action MousePressed;
    public Action MouseReleased;

    private SpriteRenderer buttonRenderer;

    private void Awake()
    {
        buttonRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnMouseDown()
    {
        MousePressed?.Invoke();
    }
    private void OnMouseUpAsButton() 
    {
        MouseReleased?.Invoke();
    }

    public void SetRendererColor(Color buttonTint) 
    {
        if (buttonRenderer == null) return;

        buttonRenderer.color = buttonTint;
    }
    public void SetButtonSprite(Sprite sprite) 
    {
        if (buttonRenderer == null) return;

        buttonRenderer.sprite = sprite;
    }
}