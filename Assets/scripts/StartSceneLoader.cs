using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneLoader : MonoBehaviour
{
    [SerializeField]
    string loadSceneName = "";

    private void Awake()
    {
        CreateScene();
        Destroy(gameObject);
    }

    void CreateScene()
    {
        if (!SceneManager.GetSceneByName(loadSceneName).isLoaded)
        {
            SceneManager.LoadScene(loadSceneName,LoadSceneMode.Additive);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
