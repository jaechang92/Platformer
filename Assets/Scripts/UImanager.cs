using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    

    public void StartBtn(string scene)
    {
        SceneManager.LoadScene(scene,LoadSceneMode.Single);
    }

    public void AppExit()
    {
        Application.Quit();
    }


}
