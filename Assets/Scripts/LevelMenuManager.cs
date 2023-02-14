using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using System.Text.RegularExpressions;

public class LevelMenuManager : MonoBehaviour
{
    // Misc Variables
    public static string lvlLocation;
    public static Color lvlColor = Color.white;
    public static Sprite[] spritearray;
    public static string LEVEL_REACHED_KEY;
    int LEVEL_REACHED = 0;


    // Menu Variables
    public GameObject levelPrefab;
    [SerializeField] GameObject indicator;
    [SerializeField] GameObject menuGrid;
    [SerializeField] GameObject typeMenu;


    // Fixed Shifting Variables
    [SerializeField] GameObject shiftPrefab;
    [SerializeField] GameObject currentShiftPrefab;

    const int MIN_SHIFTS = 0;
    const int SHIFT_GAP = 75;
    const int SHIFT_SIZE = 800;
    const float LEVELS_PER_SHIFT = 12f;
    const float SHIFT_DURATION = 1f;

    // Changing Shifting Variables
    public int MAX_SHIFTS;
    public bool isShifting;
    int shift;
    int lastShift = -1;


    public int DEBUG_EXTRA_LEVELS = 0;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Level Menu Manager Start");

        // Set Type Menu to Inactive
        typeMenu.SetActive(false);

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
        //List<Sprite> array = spritearray.OrderBy(sprite => sprite.name).ToList();
        spritearray = Sort(spritearray);
        //spritearray.Sort(spritearray, function(g1, g2) String.Compare(g1.name, g2.name));

        foreach (Sprite s in spritearray)
        {
            Debug.Log(s.name);
        }

        //spritearray = Sort(spritearray);
        int levelCount = spritearray.Length + DEBUG_EXTRA_LEVELS;

        // Create Level Selector Buttons
        for (int i = 1; i <= levelCount; i++)
        {
            GameObject lvlBtn = Instantiate(levelPrefab, menuGrid.transform, false);
            lvlBtn.GetComponent<LevelSelector>().ChangeText(i.ToString());

            // Change Color
            //Image lvlImg = lvlBtn.GetComponent<Image>();
            //lvlImg.color = lvlColor;

            // Deactivate button if not yet unlocked
            if (i > LEVEL_REACHED)
            {
                Button btnComponent = lvlBtn.GetComponent<Button>();
                btnComponent.interactable = false;
            }
        }

        MAX_SHIFTS = (int)Mathf.Ceil(levelCount / LEVELS_PER_SHIFT) - 1;
        shift = 0;

        createIndicator(MAX_SHIFTS, shift);
    }

    // Creates Indicator using only input values
    void createIndicator(int shifts, int currentShiftIndex)
    {
        // Permanently Fix Width first time
        if (lastShift == -1)
        {
            RectTransform transformRect = indicator.GetComponent<RectTransform>();
            transformRect.sizeDelta = new Vector2(SHIFT_GAP * shifts, transformRect.sizeDelta.y);
        }

        GameObject[] shiftObjs = GameObject.FindGameObjectsWithTag("Shift");

        // Destory existing indicator
        foreach (GameObject obj in shiftObjs)
        {
            Destroy(obj);
        }

        // Recreate Indicator
        for (int i = 0; i < shifts + 1; i++)
        {
            if (i == currentShiftIndex)
            {
                Instantiate(currentShiftPrefab, indicator.transform);
            }
            else
            {
                Instantiate(shiftPrefab, indicator.transform);
            }
        }
    }

    // Co-Routine to shift the level menu
    public IEnumerator Shift(bool shiftingRight)
    {    
        if ((shift + 1 <= MAX_SHIFTS && shiftingRight) || (shift - 1 >= MIN_SHIFTS && !shiftingRight))
        {
            // Update shifting status
            isShifting = true;

            // Change the shift number
            shift += (shiftingRight) ? 1 : -1;

            // Find New Transform position
            Vector3 pos = menuGrid.transform.localPosition;
            Vector3 newPos = new Vector3(-1 * shift * SHIFT_SIZE, pos.y, pos.z);

            // Recreate Indicator
            createIndicator(MAX_SHIFTS, shift);

            // Begin Shifting Menu
            float t = 0f;
            while (t <= SHIFT_DURATION)
            {
                t += Time.deltaTime;
                menuGrid.transform.localPosition = Vector3.Lerp(pos, newPos, Mathf.SmoothStep(0f, SHIFT_DURATION, t));
                yield return null;
            }

            isShifting = false;
        }

        yield return null;
    }

    private Sprite[] Sort(Sprite[] array)
    {
        // Create empty array
        Sprite[] arr = new Sprite[array.Length];

        Debug.Log(array.Length);
        for (int i = 0; i < array.Length; i++)
        {
            // Current & Next Sprite
            Sprite curr = array[i];
            //int currNum = int.Parse(curr.name.Substring(curr.name.IndexOf("#") + 1));
            //int nextNum = int.Parse(next.name.Substring(next.name.IndexOf("#") + 1));
            //Debug.Log("Before: " + currNum + "\t After: " + nextNum);

            int currNum = int.Parse(Regex.Match(array[i].name, @"\d+").Value);
            //int nextNum = int.Parse(Regex.Match(array[i + 1].name, @"\d+").Value);

            arr[currNum - 1] = array[i];

            //Debug.Log("Before: " + currNum + "\t After: " + nextNum);

            //Debug.Log("i: " + i);

            /*int j = i;
            bool notdone = true;
            while  (j >= 0 && notdone)
            {
                Debug.Log("J: " + j);
                //Debug.Log("Before: " + array[j].name + "\t After: " + array[j+1].name + "\t Compare: ");
                //int currNum = int.Parse(array[j].name.Substring(array[j].name.IndexOf("#") + 1));
                //int nextNum = int.Parse(array[j + 1].name.Substring(array[j + 1].name.IndexOf("#") + 1));

                int currNum = int.Parse(Regex.Match(array[j].name, @"\d+").Value);
                int nextNum = int.Parse(Regex.Match(array[j + 1].name, @"\d+").Value);


                if (currNum < nextNum)
                {
                    notdone = false;
                } else
                {
                    Sprite temp = array[i];
                    array[i + 1] = array[i];
                    array[i] = temp;
                }

                j--;
            }
            */
        }

        Debug.Log(arr.Length);

        return arr;

    }
}
