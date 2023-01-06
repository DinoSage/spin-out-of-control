using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textField;
   public void Click()
    {
        GameLevelManager.currLevelIndex = int.Parse(textField.text) - 1;
        SceneManager.LoadScene("GameScene");
    }

    public void ChangeText(string text)
    {
        textField.text = text;
    }


}
