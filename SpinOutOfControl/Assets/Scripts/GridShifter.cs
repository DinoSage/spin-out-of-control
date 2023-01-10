using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridShifter : MonoBehaviour
{
    [SerializeField] LevelMenuManager lvlManger;

    public void ShiftGridLeft()
    {
        if (!lvlManger.isShifting)
            StartCoroutine(lvlManger.Shift(false));
    }

    public void ShiftGridRight()
    {
        if (!lvlManger.isShifting)
            StartCoroutine(lvlManger.Shift(true));
    }
}
