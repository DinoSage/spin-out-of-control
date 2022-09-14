using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //Constants
    //public const int MAX_LEVELS;

    // Variables
    public List<GameObject> levels;
    public GameObject currentLevel;
    public int currLevelIndex;
    [SerializeField] GameObject player;

    private void Awake()
    {
        //Add to Instances class
        Instances.LEVEL_MANAGER = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Starting Level
        currLevelIndex = 0;
        SetLevel(currLevelIndex);
        //MAX_LEVELS = levels.length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLevel(int index)
    {
        if (index >= 0 && index < levels.Count)
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
            currentLevel.transform.localPosition = new Vector3(0, 0, 0);

            // Set Player Position Based on Level's Details
            Vector2 initPos = currentLevel.GetComponent<LvlDetails>().PlayerPos;

            player.transform.SetPositionAndRotation(new Vector3(initPos.x, initPos.y), Quaternion.identity);

            //Reactivate Player
            player.SetActive(true);
        }
    }
}
