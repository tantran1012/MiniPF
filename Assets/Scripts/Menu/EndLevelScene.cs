using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelScene : MonoBehaviour
{ 
    public void Replay()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().path);
    }
    public void Menu()
    {
        LoadScene("Assets/Scenes/UI/Start Scene.unity");
    }
    public void Next()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void LoadScene(string path)
    {
        SceneManager.LoadSceneAsync(path);
    }
}
