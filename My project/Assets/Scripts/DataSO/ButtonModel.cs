using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ScriptableObject representing the data for a Simon Says button.
/// </summary>
[CreateAssetMenu(fileName = "New Button Data", menuName = "SimonSays/Button")]
public class ButtonModel : ScriptableObject
{
    [SerializeField] private Sprite buttonPressedSprite;
    [SerializeField] private Sprite buttonReleasedSprite;
    [SerializeField] private ButtonType buttonType;
    [SerializeField] private Color buttonColor;
    [SerializeField] private AudioClip buttonSound;

    public Sprite ButtonPressedSprite => buttonPressedSprite;
    public Sprite ButtonReleasedSprite => buttonReleasedSprite;
    public ButtonType ButtonType => buttonType;
    public Color ButtonColor => buttonColor;
    public AudioClip ButtonSound => buttonSound;
}
/// <summary>
/// Enum representing the type of a Simon Says button.
/// </summary>
public enum ButtonType
{
    Button_1,
    Button_2,
    Button_3,
    Button_4,
    Button_5,
    Button_6,
    Count
}
