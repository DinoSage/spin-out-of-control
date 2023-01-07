using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{

    // Variables
    public GameObject currentLevel;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // Create the first current level object
        this.currentLevel = new GameObject();

        // Set level's parent, position, and add appropriate components
        currentLevel.transform.SetParent(transform);
        currentLevel.transform.localPosition = new Vector3(0, 0, 0);
        SpriteRenderer renderer = currentLevel.AddComponent<SpriteRenderer>();
        PolygonCollider2D polygonCollider2D = currentLevel.AddComponent<PolygonCollider2D>();

        // Change level to selected index
        ChangeLevel(LevelManager.currLevelIndex);

    }
    void Update()
    {
        // Key Input to return to level selector
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("LevelScene");
        }
    }

    public void ChangeLevel(int index)
    {
        var spritearray = LevelManager.spritearray;

        // Ensure index is within bounds
        if (index >= 0 && index < spritearray.Length)
        {
            //Set Player as Inactive
            player.SetActive(false);

            //Reset Level Orientation
            currentLevel.transform.localRotation = Quaternion.identity;

            //Update Current Index
            LevelManager.currLevelIndex = index;

            //Change Sprite Representing Current Level
            currentLevel.GetComponent<SpriteRenderer>().sprite = spritearray[index];

            //Re-create Physics Collider
            Destroy(currentLevel.GetComponent<PolygonCollider2D>());
            currentLevel.AddComponent<PolygonCollider2D>();

            //Reset Player Start Position
            Vector2 initPos = currentLevel.transform.position;
            player.transform.SetPositionAndRotation(new Vector3(initPos.x, initPos.y), Quaternion.identity);

            //Re-activate Player
            player.SetActive(true);
        }

        // Check if farthest level has changed
        LevelManager.CheckFarthestLevel();
    }

    public void NextLevel()
    {
        // Call Change Level for next index while ensuring within bounds
        ChangeLevel((LevelManager.currLevelIndex + 1) % LevelManager.spritearray.Length);
    }
}
