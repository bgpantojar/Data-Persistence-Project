using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public Text playerNameText;
    public Text playerRecordText;
    
    private void Start()
    {
        playerRecordText.text = "Best Score : " + MenuManager.Instance.recordplayerName + " : " + MenuManager.Instance.recordplayerScore;
    }

    public void StartNew()
    {
        MenuManager.Instance.playerName = playerNameText.text;
        //Debug.Log("Test");
        //MenuManager.Instance.SaveName();        
        SceneManager.LoadScene(1);
        
    }

    public void Exit()
    {
        //MainManager.Instance.SaveColor();

        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
                        Application.Quit(); // original code to quit Unity player
        #endif
    }
    
    //public void LoadColorClicked()
    //{
    //    MainManager.Instance.LoadColor();
    //    ColorPicker.SelectColor(MainManager.Instance.TeamColor);
    //}
}
