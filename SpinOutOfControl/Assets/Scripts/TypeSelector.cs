using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeSelector : MonoBehaviour
{
    // Variables

    [SerializeField] GameObject levels;
    [SerializeField] GameObject lvlMenu;

    int levelType = 0;
    const int CIRCLES = 0;
    const int TRIANGLES = 1;
    const int HEXAGONS = 2;

    [SerializeField] string circle_location;
    [SerializeField] GameObject circlePrefab;

    [SerializeField] string triangle_location;
    [SerializeField] GameObject trinaglePrefab;

    [SerializeField] string hexagon_location;
    [SerializeField] GameObject hexagonPrefab;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchType(int type)
    {
        switch(type)
        {
            case CIRCLES:
                //LevelMenuManager.lvlLocation = circle_location;
                //LevelMenuManager.levelPrefab = circlePrefab;
                break;
            case TRIANGLES:
                //LevelMenuManager.lvlLocation = triangle_location;
                //LevelMenuManager.levelPrefab = circlePrefab;
                break;
            case HEXAGONS:
                ///LevelMenuManager.lvlLocation = hexagon_location;
                //LevelMenuManager.levelPrefab = circlePrefab;
                break;
        }

        GameObject oldMenu = GameObject.Find("LevelsMenu");
        Destroy(oldMenu);
        Instantiate(lvlMenu, this.transform.parent);

        closeTypeSelectionMenu();
    }

    public void closeTypeSelectionMenu()
    {
        this.gameObject.SetActive(false);
    }
}
