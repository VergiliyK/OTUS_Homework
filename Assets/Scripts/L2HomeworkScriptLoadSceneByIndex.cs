using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L2HomeworkScriptLoadSceneByIndex : MonoBehaviour
{
    public int SceneIndex;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(SceneIndex, LoadSceneMode.Single);
        }
    }
}
