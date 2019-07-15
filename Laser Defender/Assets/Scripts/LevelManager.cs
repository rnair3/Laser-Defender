using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float delay = 2f;

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadMainScene()
    {
        FindObjectOfType<GameSession>().ResetScore();
        SceneManager.LoadScene("Game");
        
    }

    public void LoadGameOver()
    {
        StartCoroutine(AddDelay());
        
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator AddDelay()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Game Over");
    }
}
