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

        // Initialize Sprite Array
        lvlManager.spritearray = Resources.LoadAll<Sprite>("levels");

        // Create current level object

        lvlManager.currentLevel = new GameObject();

        GameObject lvl = lvlManager.currentLevel;

        lvl.transform.SetParent(lvlManager.transform);
        lvl.transform.localPosition = new Vector3(0, 0, 0);

        SpriteRenderer renderer = lvl.AddComponent<SpriteRenderer>();


        lvl.name = "levels";

        PolygonCollider2D polygonCollider2D = lvl.AddComponent<PolygonCollider2D>();
        //polygonCollider2D.enabled = true;

        LvlDetails lvld = lvl.AddComponent<LvlDetails>();
        lvld.PlayerPos.Set(0, 0);

        //levels.Add(lvl1);

        //Starting Level
        lvlManager.currLevelIndex = 0;
        lvlManager.SetLevel(lvlManager.currLevelIndex);

    }
}
