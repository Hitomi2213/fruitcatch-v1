using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneJump : MonoBehaviour
{
    [SerializeField]
    string SceneName;

    public void OnJump()
    {
        SceneManager.LoadScene(SceneName);
    }

   
}
