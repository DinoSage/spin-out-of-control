using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridShifter : MonoBehaviour
{
    [SerializeField] LevelManager lvlManger;

    public void ShiftGridLeft()
    {
        StartCoroutine(lvlManger.Shift(false));
    }

    public void ShiftGridRight()
    {
        StartCoroutine(lvlManger.Shift(true));
    }
}
