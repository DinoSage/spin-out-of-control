using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static Sprite[] spritearray;
    public string lvlLocation;
    public static int currLevelIndex;

    [SerializeField] GameObject circleLevel;

    [SerializeField] GameObject levelGrid;

    // The farthest level reached by player
    public static int latest;
    public static string latestKey = "FARTHEST_LEVEL";

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start!!!!");
        // Retrive Farthest Level reached
        latest = PlayerPrefs.GetInt(latestKey, -1);

        if (latest < 1)
        {
            // Define FarthestLevel
            latest = 1;
            PlayerPrefs.SetInt(latestKey, latest);
        }


        // Load levels
        spritearray = Resources.LoadAll<Sprite>(lvlLocation);
        int levelCount = spritearray.Length + 50;

        // Create Level Selector Buttons
        for (int i = 1; i <= levelCount; i++)
        {
            Debug.Log(i);
            GameObject lvlBtn = Instantiate(circleLevel, this.transform, false);
            lvlBtn.GetComponent<LevelSelector>().ChangeText(i.ToString());

            // Deactivate button if not yet unlocked
            if (i > latest)
            {
                Button btnComponent = lvlBtn.GetComponent<Button>();
                btnComponent.interactable = false;
            }
        }
    }

    // Updates farthest level if it has changed
    public static void CheckFarthestLevel()
    {
        Debug.Log("Entered!");
        if ((currLevelIndex + 1) > latest)
        {
            latest = currLevelIndex + 1;
            PlayerPrefs.SetInt(latestKey, latest);
        }
    }
}
