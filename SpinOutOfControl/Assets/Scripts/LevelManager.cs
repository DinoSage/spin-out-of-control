using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    // Variables
    public GameObject currentLevel;
    public int currLevelIndex;
    public string lvlLocation;
    public Sprite[] spritearray;
    [SerializeField] GameObject player;

    // Commands
    LvlSetupCommand lvlSetup = new LvlSetupCommand();

    private void Awake()
    {
        //Add to Instances class
        Instances.LEVEL_MANAGER = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Setup the levels
        lvlSetup.Execute();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetLevel(int index)
    {
        if (index >= 0 && index < spritearray.Length)
        {
            player.SetActive(false);

            //Reset Level Orientation
            currentLevel.transform.Rotate(0, 0, 0);

            //Set Current Index
            currLevelIndex = index;

            //Create and Reassign Current Level Instance
            currentLevel.GetComponent<SpriteRenderer>().sprite = spritearray[index];

            Destroy(currentLevel.GetComponent<PolygonCollider2D>());
            currentLevel.AddComponent<PolygonCollider2D>();

            //Set Player Position Based on Level's Details
            //Vector2 initPos = currentLevel.GetComponent<LvlDetails>().PlayerPos;
            Vector2 initPos = currentLevel.transform.position;

            player.transform.SetPositionAndRotation(new Vector3(initPos.x, initPos.y), Quaternion.identity);

            //Reactivate Player
            player.SetActive(true);
        }
    }
}
