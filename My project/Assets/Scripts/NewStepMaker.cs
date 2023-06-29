using System.Collections.Generic;
using UnityEngine;

public class NewStepMaker : MonoBehaviour
{
    private int buttonAmount;
    private List<ButtonType> steps = new List<ButtonType>();
    private void OnEnable()
    {
        GameplayEvents.Instance.StartButtonClicked += StartGame;
    }
    private void OnDisable()
    {
        GameplayEvents.Instance.StartButtonClicked -= StartGame;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            MakeNewStep();
    }

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
