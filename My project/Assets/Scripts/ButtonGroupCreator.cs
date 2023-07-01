using UnityEngine;

/// <summary>
/// This class responsible for creating button groups in the Simon Says game.
/// </summary>
[RequireComponent(typeof(ButtonGroupDataInjector))]
public class ButtonGroupCreator : MonoBehaviour
{
    [SerializeField] private GameObject[] buttonGroups;
    [SerializeField] private Transform buttonGroupParent;

    private ButtonGroupDataInjector buttonGroupDataInjector;

    private void Awake()
    {
        buttonGroupDataInjector = GetComponent<ButtonGroupDataInjector>();
    }

    /// <summary>
    /// Sets the amount of buttons in the game and creates the corresponding button group.
    /// </summary>
    /// <param name="buttonAmount">The amount of buttons to create.</param>
    public void SetAmountOfButtons(int buttonAmount)
    {
        int buttonGroupIndex = buttonAmount - GameConstants.MinimumAmountOfButtons;

        if (buttonGroupIndex < 0)
        {
            Debug.LogError("SetAmountOfButtons: button group index is less than 0 - error");
            return;
        }

        CreateButtonGroup(buttonGroups[buttonGroupIndex]);
    }

    private void CreateButtonGroup(GameObject buttonGroup)
    {
        if (buttonGroup == null)
        {
            Debug.LogError("CreateButtonGroup: button group is null - error");
            return;
        }

        GameObject buttonGroupObj = Instantiate(buttonGroup, buttonGroupParent);

        ButtonGroup buttonGroupComponent = buttonGroupObj.GetComponent<ButtonGroup>();
        if (buttonGroupComponent != null)
        {
            buttonGroupDataInjector.SetButtonControllers(buttonGroupComponent.ButtonControllers);
        }
    }
}