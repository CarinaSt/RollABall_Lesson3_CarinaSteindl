using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamerManager : MonoBehaviour
{

    public void EnterLevel()
    {
        SceneManager.LoadScene("MainScene");

    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void ExitGame()
    {

#if UNITY_EDITOR // end game - only in editor
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
    }
}
