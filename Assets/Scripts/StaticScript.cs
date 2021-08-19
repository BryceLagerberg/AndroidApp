using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StaticScript : MonoBehaviour
{
    public static void LoadScene(string SceneName)
    {
        Debug.Log($"Loading {SceneName}");
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName);
    }
}
