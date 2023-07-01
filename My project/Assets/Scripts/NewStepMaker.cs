using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generates new steps and notifies the game system when a new step is made.
/// </summary>
public class NewStepMaker : MonoBehaviour
{
    private int buttonAmount;
    private List<ButtonType> steps = new List<ButtonType>();

    private void OnEnable()
    {
        GameplayEvents.Instance.StartButtonClicked += StartGame;
        GameplayEvents.Instance.PlayerFinishedSequenceSuccessfully += MakeNewStep;
    }

    private void OnDisable()
    {
        if (GameplayEvents.Instance == null) return;

        GameplayEvents.Instance.StartButtonClicked -= StartGame;
        GameplayEvents.Instance.PlayerFinishedSequenceSuccessfully -= MakeNewStep;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            MakeNewStep();
    }

    /// <summary>
    /// Sets the maximum amount of buttons for step generation.
    /// </summary>
    /// <param name="buttonAmount">The maximum button amount.</param>
    public void SetMaximumButtonAmount(int buttonAmount)
    {
        this.buttonAmount = buttonAmount;
    }

    private void StartGame()
    {
        Debug.Log("StartGame: Game started!");
        steps = new List<ButtonType>();
        MakeNewStep();
    }

    private void MakeNewStep()
    {
        int newStep = Random.Range(0, buttonAmount);
        steps.Add((ButtonType)newStep);
        Debug.Log($"MakeNewStep: New step made {(ButtonType)newStep}");
        GameplayEvents.Instance.NewStepMade(steps);
    }
}