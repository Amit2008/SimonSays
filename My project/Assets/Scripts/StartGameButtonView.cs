using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButtonView : MonoBehaviour
{
    public Action StartButtonClicked;
    
    public void OnStartButtonClick() => StartButtonClicked?.Invoke();
}
