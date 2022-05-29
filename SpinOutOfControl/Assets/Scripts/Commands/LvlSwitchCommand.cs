using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlSwitchCommand : Command
{
    LevelManager lvlManager;

    public void Execute()
    {
        lvlManager = Instances.LEVEL_MANAGER;
        Debug.Log("LvlManager: " + (lvlManager == null));
        int currentIndex = lvlManager.currLevelIndex;
        lvlManager.SetLevel((currentIndex + 1) % LevelManager.MAX_LEVELS);
    }
}
