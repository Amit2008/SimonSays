using UnityEngine;

public class LevelButtonCreator : MonoBehaviour
{
    [SerializeField] private string[] levelNames;
    [SerializeField] private Transform container;
    [SerializeField] private GameObject levelButtonPrefab;
    
    private void Start()
    {
        CreateLevelButtons();
    }

    private void CreateLevelButtons() 
    {
        if (levelNames != null && levelNames.Length > 0) 
        {
            foreach (var levelName in levelNames)
            {
                GameObject levelButtonObj = Instantiate(levelButtonPrefab, container);

                LevelButtonController levelButtonController = levelButtonObj.GetComponent<LevelButtonController>();
                if (levelButtonController == null) 
                {
                    Debug.LogError("CreateLevelButtons: levelButtonController  is null - error");
                    return;
                }

                levelButtonController.SetButton(levelName);
            }
        }
    }
}