using UnityEngine;

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
