using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textField;
    [SerializeField] LevelManager lvlManger;

   public void Click()
    {
        // Specify strating level
        LevelManager.currLevelIndex = int.Parse(textField.text) - 1;
        SceneManager.LoadScene("GameScene");
    }

    // Non-Click Methods
    public void ChangeText(string text)
    {
        textField.text = text;
    }
}
