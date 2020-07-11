using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public List<GameObject> ativeObject;
    private void Awake()
    {
        instance = this;
    }


    public Inventory inven;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ClickUIIcon(GameObject gameObject)
    {
        gameObject.SetActive(true);
        ativeObject.Add(gameObject);
    }

    public void ExitUI()
    {

        GameObject tmp;
        tmp = ativeObject[ativeObject.Count - 1];

        ativeObject[ativeObject.Count - 1].SetActive(false);
        ativeObject.RemoveAt(ativeObject.Count - 1);
        while (tmp == ativeObject[ativeObject.Count - 1])
        {
            ativeObject.RemoveAt(ativeObject.Count - 1);
            if (ativeObject.Count - 1 < 0)
            {
                break;
            }
        }

    }







    public void StartBtn(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void AppExit()
    {
        Application.Quit();
    }


}
