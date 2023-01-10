using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenuManager : MonoBehaviour
{
    public static Sprite[] spritearray;
    public string lvlLocation;
    public GameObject levelPrefab;

    public static int currLevelIndex;


    // The farthest level reached by player
    int LEVEL_REACHED;
    public const string LEVEL_REACHED_KEY = "LEVEL_REACHED";

    // Shifting Variables
    public int MAX_SHIFTS;
    const int MIN_SHIFTS = 0;
    public int shift;
    public int SHIFT_SIZE;
    public float LEVELS_PER_SHIFT;
    public float SHIFT_DURATION;
    public bool isShifting;

    public int DEBUG_EXTRA_LEVELS = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Retrive Farthest Level reached
        LEVEL_REACHED = PlayerPrefs.GetInt(LEVEL_REACHED_KEY, -1);

        if (LEVEL_REACHED < 1)
        {
            // Define FarthestLevel
            LEVEL_REACHED = 1;
            PlayerPrefs.SetInt(LEVEL_REACHED_KEY, LEVEL_REACHED);
        }

        // Load levels
        spritearray = Resources.LoadAll<Sprite>(lvlLocation);
        int levelCount = spritearray.Length + DEBUG_EXTRA_LEVELS;

        // Create Level Selector Buttons
        for (int i = 1; i <= levelCount; i++)
        {
            GameObject lvlBtn = Instantiate(levelPrefab, this.transform, false);
            lvlBtn.GetComponent<LevelSelector>().ChangeText(i.ToString());

            // Deactivate button if not yet unlocked
            if (i > LEVEL_REACHED)
            {
                Button btnComponent = lvlBtn.GetComponent<Button>();
                btnComponent.interactable = false;
            }
        }

        MAX_SHIFTS = (int)Mathf.Ceil(levelCount / LEVELS_PER_SHIFT) - 1;
        shift = 0;
    }

    public IEnumerator Shift(bool shiftingRight)
    {    

        if ((shift + 1 <= MAX_SHIFTS && shiftingRight) || (shift - 1 >= MIN_SHIFTS && !shiftingRight))
        {
            // Update shifting status
            isShifting = true;

            // Change the shift number
            shift += (shiftingRight) ? 1 : -1;

            // Find & Change Transform position
            Vector3 pos = this.transform.localPosition;
            Vector3 newPos = new Vector3(-1 * shift * SHIFT_SIZE, pos.y, pos.z);
            //this.transform.localPosition = newPos;

            float t = 0f;
            while (t <= SHIFT_DURATION)
            {
                t += Time.deltaTime;
                this.transform.localPosition = Vector3.Lerp(pos, newPos, Mathf.SmoothStep(0f, SHIFT_DURATION, t));
                yield return null;
            }

            isShifting = false;
        }

        yield return null;
    }
}
