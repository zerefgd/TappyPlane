using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void GameStart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
