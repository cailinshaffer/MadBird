using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private static int _nextLevelIndex = 1;
    private Enemy[] _enemies;

    private void OnEnable ()
        {
            _enemies = FindObjectsOfType<Enemy>();
        }
    

    // Update is called once per frame
    void Update()
    {
        // check if all enemies are dead
        foreach(Enemy enemy in _enemies)
        {
            if (enemy != null)
                return;
        }
        Debug.Log("Enemy Killed!");
        // load next level
        _nextLevelIndex++;
        string nextLevelName = "Level" + _nextLevelIndex;
        SceneManager.LoadScene(nextLevelName);
    }
}
