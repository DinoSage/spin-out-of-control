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

    // The farthest level reached by player
    public static int latest;
    public static string latestKey = "FARTHEST_LEVEL";

    public int MAX_SHIFTS;
    public int MIN_SHIFTS = 0;
    public int shift;
    public int SHIFT_SIZE;
    public float LEVELS_PER_SHIFT;

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
            GameObject lvlBtn = Instantiate(circleLevel, this.transform, false);
            lvlBtn.GetComponent<LevelSelector>().ChangeText(i.ToString());

            // Deactivate button if not yet unlocked
            if (i > latest)
            {
                Button btnComponent = lvlBtn.GetComponent<Button>();
                btnComponent.interactable = false;
            }
        }

        MAX_SHIFTS = (int) Mathf.Ceil(levelCount / LEVELS_PER_SHIFT) - 1;
        shift = 0;
    }

    // Updates farthest level if it has changed
    public static void CheckFarthestLevel()
    {
        if ((currLevelIndex + 1) > latest)
        {
            latest = currLevelIndex + 1;
            PlayerPrefs.SetInt(latestKey, latest);
        }
    }

    public IEnumerator Shift(bool shiftingRight)
    {
        Debug.Log("Checking right: " + (shift + 1 <= MAX_SHIFTS && shiftingRight));
        Debug.Log("Checking left: " + (shift - 1 >= MIN_SHIFTS && !shiftingRight));
        Debug.Log(shiftingRight);

        if ((shift + 1 <= MAX_SHIFTS && shiftingRight) || (shift - 1 >= MIN_SHIFTS && !shiftingRight))
        {
            // Change the shift number
            shift += (shiftingRight) ? 1 : -1;

            // Find & Change Transform position
            Vector3 pos = this.transform.localPosition;
            Vector3 newPos = new Vector3(-1 * shift * SHIFT_SIZE, pos.y, pos.z);
            this.transform.localPosition = newPos;
        }

        yield return null;
    }
}
