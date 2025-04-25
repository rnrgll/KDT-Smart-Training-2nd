using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    public void Init()
    {
        
    }

    public void LoadScene(string sceneName=null)
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        SceneManager.LoadScene(sceneName);
    }
}
