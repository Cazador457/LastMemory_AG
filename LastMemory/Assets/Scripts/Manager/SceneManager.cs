using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Start");
    }
    public void RestartGame()
    {

    }

    public void Exit() //=> Application.Quit();
    {
        Debug.Log("Exit");
    } 
}
