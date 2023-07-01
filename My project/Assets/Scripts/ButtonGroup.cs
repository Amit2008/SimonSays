using UnityEngine;

/// <summary>
/// This class representing a group of Simon Says buttons.
/// </summary>
public class ButtonGroup : MonoBehaviour
{
    [SerializeField] private ButtonController[] buttonControllers;

    public ButtonController[] ButtonControllers => buttonControllers;

    private void Awake()
    {
        for (int controllerIndex = 0; controllerIndex < buttonControllers.Length; controllerIndex++)
        {
            buttonControllers[controllerIndex].gameObject.name = $"Button_{controllerIndex}";
        }
    }
}
