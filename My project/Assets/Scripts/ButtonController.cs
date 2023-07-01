using System.Collections;
using UnityEngine;

/// <summary>
/// This class responsible for managing a Simon Says button.
/// </summary>
[RequireComponent(typeof(CircleCollider2D))]
public class ButtonController : MonoBehaviour
{
    private Sprite buttonPressedSprite;
    private Sprite buttonReleasedSprite;
    private ButtonView buttonView;
    private ButtonModel buttonModel;
    private CircleCollider2D circleCollider2D;
    private bool permaColliderDisable = false;

    private void Awake()
    {
        CacheButtonView();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void OnEnable()
    {
        buttonView.MousePressed += OnButtonPressed;
        buttonView.MouseReleased += OnButtonReleased;

        GameplayEvents.Instance.SystemStartPlayingSteps += DisableButton;
        GameplayEvents.Instance.PlayerMadeBadSequence += DisableColliderPermanently;
        GameplayEvents.Instance.TimeFinished += DisableColliderPermanently;
        GameplayEvents.Instance.SystemPlayedAllSteps += EnableButton;
        GameplayEvents.Instance.SystemPlayedStep += PlayButton;
    }

    private void OnDisable()
    {
        if (buttonView == null || GameplayEvents.Instance == null) return;

        buttonView.MousePressed -= OnButtonPressed;
        buttonView.MouseReleased -= OnButtonReleased;

        GameplayEvents.Instance.SystemStartPlayingSteps -= DisableButton;
        GameplayEvents.Instance.PlayerMadeBadSequence -= DisableColliderPermanently;
        GameplayEvents.Instance.TimeFinished -= DisableColliderPermanently;
        GameplayEvents.Instance.SystemPlayedAllSteps -= EnableButton;
        GameplayEvents.Instance.SystemPlayedStep -= PlayButton;
    }

    /// <summary>
    /// Sets the data for the button.
    /// </summary>
    /// <param name="buttonModel">The data model for the button.</param>
    public void SetButtonData(ButtonModel buttonModel)
    {
        buttonPressedSprite = buttonModel.ButtonPressedSprite;
        buttonReleasedSprite = buttonModel.ButtonReleasedSprite;
        buttonView.SetButtonSprite(buttonReleasedSprite);
        buttonView.SetRendererColor(buttonModel.ButtonColor);
        this.buttonModel = buttonModel;
    }

    private void CacheButtonView()
    {
        if (buttonView == null)
            buttonView = GetComponent<ButtonView>();
    }

    private void OnButtonPressed()
    {
        if (buttonPressedSprite == null) return;

        Debug.Log("Button is pressed");
        buttonView.SetButtonSprite(buttonPressedSprite);
        GameplayEvents.Instance.ButtonPressed?.Invoke(buttonModel);
    }

    private void OnButtonReleased()
    {
        if (buttonReleasedSprite == null) return;

        Debug.Log("Button is released");
        buttonView.SetButtonSprite(buttonReleasedSprite);
    }

    private void DisableColliderPermanently()
    {
        permaColliderDisable = true;
        DisableButton();
    }

    private void DisableButton()
    {
        ChangeButtonColliderInteractionState(false);
    }

    private void EnableButton()
    {
        if (!permaColliderDisable)
        {
            ChangeButtonColliderInteractionState(true);
        }
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
