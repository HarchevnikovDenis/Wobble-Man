using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Floor", 1));
    }
}
