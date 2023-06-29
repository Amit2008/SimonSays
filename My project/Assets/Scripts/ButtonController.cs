using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ButtonController : MonoBehaviour
{
    private Sprite buttonPressedSprite;
    private Sprite buttonReleasedSprite;
    private ButtonView buttonView;
    private ButtonModel buttonModel;
    private CircleCollider2D circleCollider2D;
    private void Awake()
    {
        CasheButtonView();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }
    private void OnEnable()
    {
        buttonView.MousePressed += OnButtonPressed;
        buttonView.MouseReleased += OnButtonReleased;

        GameplayEvents.Instance.SystemStartPlayingSteps += DisableButton;
        GameplayEvents.Instance.SystemPlayedAllSteps += EnableButton;
        GameplayEvents.Instance.SystemPlayedStep += PlayButton;
    }
    private void OnDisable()
    {
        buttonView.MousePressed -= OnButtonPressed;
        buttonView.MouseReleased -= OnButtonReleased;
        
        GameplayEvents.Instance.SystemStartPlayingSteps -= DisableButton;
        GameplayEvents.Instance.SystemPlayedAllSteps -= EnableButton;
        GameplayEvents.Instance.SystemPlayedStep -= PlayButton;
    }
    public void SetButtonData(ButtonModel buttonModel) 
    {
        buttonPressedSprite = buttonModel.ButtonPressedSprite;
        buttonReleasedSprite = buttonModel.ButtonReleasedSprite;
        buttonView.SetButtonSprite(buttonReleasedSprite);
        buttonView.SetRendererColor(buttonModel.ButtonColor);
        this.buttonModel = buttonModel;
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
        GameplayEvents.Instance.ButtonPressed?.Invoke(buttonModel);
    }
    private void OnButtonReleased()
    {
        if (buttonReleasedSprite == null) return;

        Debug.Log($"button is released");
        buttonView.SetButtonSprite(buttonReleasedSprite);
    }

    private void DisableButton() 
    {
        ChangeButtonColliderInteractionState(false);
    }
    private void EnableButton()  
    {
        ChangeButtonColliderInteractionState(true);
    }
    private void ChangeButtonColliderInteractionState(bool state) 
    {
        circleCollider2D.enabled = state;
    }

    private void PlayButton(ButtonType buttonType, float delay) 
    {
        if (buttonType != buttonModel.ButtonType) return;
        StartCoroutine(AutoPlaySequence(delay));
    }

    private IEnumerator AutoPlaySequence(float delay) 
    {
        OnButtonPressed();
        yield return new WaitForSeconds(delay);
        OnButtonReleased();
    }
}
