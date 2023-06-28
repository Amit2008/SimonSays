using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private Sprite buttonPressedSprite;
    private Sprite buttonReleasedSprite;
    private ButtonType buttonType;
    private ButtonView buttonView;
    private ButtonModel buttonModel;
    private void Awake()
    {
        CasheButtonView();
    }
    private void OnEnable()
    {
        buttonView.MousePressed += OnButtonPressed;
        buttonView.MouseReleased += OnButtonReleased;
    }
    private void OnDisable()
    {
        buttonView.MousePressed -= OnButtonPressed;
        buttonView.MouseReleased -= OnButtonReleased;
    }
    public void SetButtonData(ButtonModel buttonModel) 
    {
        buttonPressedSprite = buttonModel.ButtonPressedSprite;
        buttonReleasedSprite = buttonModel.ButtonReleasedSprite;
        buttonType = buttonModel.ButtonType;
        buttonView.SetButtonSprite(buttonReleasedSprite);
        buttonView.SetRendererColor(buttonModel.ButtonColor);
    }

    private void CasheButtonView() 
    {
        if (buttonView == null)
            buttonView = GetComponent<ButtonView>();
    }
    private void OnButtonPressed()
    {
        if (buttonPressedSprite == null) return;

        Debug.Log($"button is pressed");
        buttonView.SetButtonSprite(buttonPressedSprite);
    }
    private void OnButtonReleased()
    {
        if (buttonReleasedSprite == null) return;

        Debug.Log($"button is released");
        buttonView.SetButtonSprite(buttonReleasedSprite);
        GameplayEvents.Instance.ButtonPressed?.Invoke(buttonModel);
    }
}
