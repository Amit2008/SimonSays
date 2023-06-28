using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGroupDataInjector : MonoBehaviour
{
    [SerializeField] private ButtonModel[] buttonModels;

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