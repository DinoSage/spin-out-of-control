using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILevelManager : MonoBehaviour
{
    public Sprite[] spritearray;
    public string lvlLocation;
    public int levelCount;
    [SerializeField] GameObject circleLevel;

    [SerializeField] GameObject levelGrid;

    // Start is called before the first frame update
    void Start()
    {
        // Get # of levels
        levelCount = Resources.LoadAll<Sprite>(lvlLocation).Length;
        Debug.Log("hi");

        for (int i = 1; i <= levelCount; i++)
        {
            Debug.Log(i);
            GameObject lvlBtn = Instantiate(circleLevel, this.transform, false);
            lvlBtn.GetComponent<LevelSelector>().ChangeText(i.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
