using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneCompletion : MonoBehaviour
{
    public ScreenFader screenFader;
    public GameObject panel;


    // Called when target of level is achieved
    public WebSocketClientExample wsController; // Drag WebSocket script here in Inspector

public void CompleteLevel(float time) 
{
    panel.SetActive(true);           // Open the panel
   
}


    // UI Button
    public void ReloadLevel ()
    {
        screenFader.FadeOut(() => SceneManager.LoadSceneAsync (gameObject.scene.buildIndex));
    }
}