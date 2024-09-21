using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementScript : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(0);
    }

    public void RulesPage()
    {
        SceneManager.LoadScene(2);
    }

    public void GoBack()
    {
        SceneManager.LoadScene(1);
    }
}
