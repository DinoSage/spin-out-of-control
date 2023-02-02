using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTypeManager : MonoBehaviour
{
    // Variables
    [SerializeField] GameObject levelsMenu;
    [SerializeField] string[] levelLocations;
    [SerializeField] Color[] levelColors;

    // Keys
    readonly string[] prefKeys = { "CIRCLES_REACHED", "TRIANGLES_REACHED", "HEXAGONS_REACHED" };

    static int currentLevelType = 0;


    // Start is called before the first frame update
    void Awake()
    {
        UpdateMenuInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Button Methods
    public void changeTypeIndex(int i)
    {
        currentLevelType = i;
    }

    public void changeLevelMenu()
    {
        // Update Values
        UpdateMenuInfo();

        // Reload Menu
        //levelsMenu.SetActive(false);
        //levelsMenu.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Helper Methods
    private void UpdateMenuInfo()
    {
        LevelMenuManager.lvlLocation = GetElementIfPossible<string>(levelLocations);
        LevelMenuManager.lvlColor = GetElementIfPossible<Color>(levelColors);
        LevelMenuManager.LEVEL_REACHED_KEY = GetElementIfPossible<string>(prefKeys);
    }
    private T GetElementIfPossible<T>(T[] array)
    {
        int index = currentLevelType;
        index = index % array.Length;
        return array[index];
    }
}
