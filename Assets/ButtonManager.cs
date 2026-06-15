using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public void OnRestartButton()
    {
        Health.health = 100;
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Перезагружаем сцену по имени
        SceneManager.LoadScene(currentSceneName);
    }
}