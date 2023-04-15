using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene("PlayMenu");
    }

    public void Options()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
