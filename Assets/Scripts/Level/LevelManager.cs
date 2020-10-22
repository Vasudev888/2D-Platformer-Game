using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get{ return instance;} }

    // public string Level1;
    public string[] Levels;
    private void Awake() {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    } 
    

    public void MarkCurrentLevelComplete(){
        Scene currentScene = SceneManager.GetActiveScene();
        //Set Level Status to complete
        Instance.SetLevelStatus(currentScene.name, LevelStatus.Completed);
        
        //Unlock the next level
        // int nextSceneIndex  = currentScene.buildIndex  + 1;
        // Scene  nextScene =  SceneManager.GetSceneByBuildIndex(nextSceneIndex);
        // Instance.SetLevelStatus(nextScene.name, LevelStatus.Unlocked);
        
        int CurrentSceneIndex =  Array.FindIndex(Levels, level => level  ==  currentScene.name);
        int nextSceneIndex = CurrentSceneIndex + 1;
        if(nextSceneIndex < Levels.Length){
            SetLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
        }
    }

    private void Start() {
       if (GetLevelStatus(Levels[0]) == LevelStatus.Locked){
           SetLevelStatus(Levels[0], LevelStatus.Unlocked);
       }
    }

    public LevelStatus  GetLevelStatus(string level){
        LevelStatus levelStatus = (LevelStatus) PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }

    public void  SetLevelStatus(string level, LevelStatus levelStatus){
        PlayerPrefs.SetInt(level, (int)levelStatus);
        Debug.Log("Setting Level: " + level + " Status: " + levelStatus);
    }
}