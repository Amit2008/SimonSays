using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class responsible for injecting button data into a button group.
/// </summary>
public class ButtonGroupDataInjector : MonoBehaviour
{
    [SerializeField] private ButtonModel[] buttonModels;

    /// <summary>
    /// Sets the button controllers in the button group with corresponding button data.
    /// </summary>
    /// <param name="buttonControllers">The button controllers in the button group.</param>
    public void SetButtonControllers(ButtonController[] buttonControllers)
    {
        for (int buttonControlerIndex = 0; buttonControlerIndex < buttonControllers.Length; buttonControlerIndex++)
        {
            if (buttonModels[buttonControlerIndex] == null)
            {
                Debug.LogError("SetButtonControllers: button model is null - error");
                break;
            }

            buttonControllers[buttonControlerIndex].SetButtonData(buttonModels[buttonControlerIndex]);
        }
    }
}