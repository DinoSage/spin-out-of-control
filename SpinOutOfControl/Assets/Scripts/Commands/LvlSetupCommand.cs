using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class LvlSetupCommand : Command
{
    LevelManager lvlManager;

    public void Execute()
    {
        lvlManager = Instances.LEVEL_MANAGER;
        List<GameObject> levels = new List<GameObject>();

    }
}
