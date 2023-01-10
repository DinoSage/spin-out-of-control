using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridShifter : MonoBehaviour
{
    [SerializeField] GameObject levelMenu;

    public void ShiftGridLeft()
    {
        // Start Shifting Coroutine (Left)
        LevelMenuManager manager = levelMenu.GetComponent<LevelMenuManager>();
        if (!manager.isShifting)
            StartCoroutine(manager.Shift(false));
    }

    public void ShiftGridRight()
    {
        // Start Shifting Coroutine (Right)
        LevelMenuManager manager = levelMenu.GetComponent<LevelMenuManager>();
        if (!manager.isShifting)
            StartCoroutine(manager.Shift(true));
    }
}
