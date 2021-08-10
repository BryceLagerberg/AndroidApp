using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string SceneName) {
        Debug.Log($"Loading {SceneName}");
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName);
    }
}
