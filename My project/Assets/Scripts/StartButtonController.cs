using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StartGameButtonView))]
public class StartButtonController : MonoBehaviour
{
    private StartGameButtonView startGameButtonView;

    private void Awake()
    {
        startGameButtonView = GetComponent<StartGameButtonView>();
    }

    private void OnEnable()
    {
        startGameButtonView.StartButtonClicked += HandleStartButtonClick;
    }
    private void OnDisable()
    {
        startGameButtonView.StartButtonClicked -= HandleStartButtonClick;
    }

    private void HandleStartButtonClick() 
    {
        GameplayEvents.Instance.StartButtonClicked?.Invoke();
        gameObject.SetActive(false);
    }
}
