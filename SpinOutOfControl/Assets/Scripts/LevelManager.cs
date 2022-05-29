using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Variables

    public List<GameObject> levels;
    public GameObject currentLevel;
    public int currLevelIndex;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //Starting Level
        currLevelIndex = 0;
        SetLevel(currLevelIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetLevel(int index)
    {
        player.SetActive(false);

        //Destroy Existing Level Instance
        if (currentLevel != null)
        {
            Destroy(currentLevel);
        }

        //Set Current Index
        currLevelIndex = index;

        //Create and Reassign Current Level Instance
        currentLevel = Instantiate(levels[index]);
        currentLevel.transform.SetParent(this.transform);

        // Set Player Position Based on Level's Details
        Vector2 initPos = currentLevel.GetComponent<LvlDetails>().PlayerPos;

        player.transform.SetPositionAndRotation(new Vector3(initPos.x, initPos.y), Quaternion.identity);

        player.SetActive(true);

    }
}
