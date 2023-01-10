using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftIndicator : MonoBehaviour
{
    // Variables
    [SerializeField] GameObject shift;
    [SerializeField] GameObject currentShift;
    [SerializeField] GameObject lvlMangerObj;

    int lastShift = -1;

    public int SHIFT_GAP = 75;
    

    // Update is called once per frame
    void Update()
    {
        LevelMenuManager lvlManager = lvlMangerObj.GetComponent<LevelMenuManager>();
        if (lvlManager.shift != lastShift)
        {
            createIndicator(lvlManager.MAX_SHIFTS, lvlManager.shift);
            lastShift = lvlManager.shift;
        }
    }

    // Helper Method
    private void createIndicator(int shifts, int currentShiftIndex)
    {

        // Permanently Fix Width first time
        if (lastShift == -1)
        {
            RectTransform transformRect = GetComponent<RectTransform>();
            transformRect.sizeDelta = new Vector2(SHIFT_GAP * shifts, transformRect.sizeDelta.y);
        }

        GameObject[] indicator = GameObject.FindGameObjectsWithTag("Shift");

        // Destory existing indicator
        foreach (GameObject obj in indicator)
        {
            Destroy(obj);
        }

        // Recreate Indicator
        for(int i = 0; i < shifts + 1; i++)
        {
            if (i == currentShiftIndex)
            {
                Instantiate(currentShift, this.transform);
            } else
            {
                Instantiate(shift, this.transform);
            }
        }
    }
}
