using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class responsible for managing the visual representation of a button.
/// </summary>
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

    private void OnMouseUp()
    {
        MouseReleased?.Invoke();
    }

    /// <summary>
    /// Sets the color of the button renderer.
    /// </summary>
    /// <param name="buttonTint">The color to set.</param>
    public void SetRendererColor(Color buttonTint)
    {
        if (buttonRenderer == null) return;

        buttonRenderer.color = buttonTint;
    }

    /// <summary>
    /// Sets the sprite of the button renderer.
    /// </summary>
    /// <param name="sprite">The sprite to set.</param>
    public void SetButtonSprite(Sprite sprite)
    {
        if (buttonRenderer == null) return;

        buttonRenderer.sprite = sprite;
    }
}