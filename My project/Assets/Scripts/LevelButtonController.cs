using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LevelButtonView))]
public class LevelButtonController : MonoBehaviour
{
    private string levelName;
    private LevelButtonView levelButtonView;

    private void Awake()
    {
        levelButtonView = GetComponent<LevelButtonView>();
    }
    private void OnEnable()
    {
        levelButtonView.LevelButtonClicked += SetLevelNameToLoad;
    }
    private void OnDisable()
    {
        levelButtonView.LevelButtonClicked -= SetLevelNameToLoad;
    }

    public void SetButton(string levelName) 
    {
        this.levelName = levelName;
        levelButtonView.SetButtonText(levelName.ToUpper());
    }

    private void SetLevelNameToLoad() 
    {
        GameplayHelper.FileName = levelName;
        MainMenuEvents.Instance.LevelNameSet?.Invoke();
    }
}
