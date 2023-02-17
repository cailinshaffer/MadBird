using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private static int _nextLevelIndex = 1;
    // nextLevelIndex will start at 1
    private Enemy[] _enemies;

    private void OnEnable ()
        {
            // find all enemies availble and once dead boot to next level
            _enemies = FindObjectsOfType<Enemy>();
        }
    

    // Update is called once per frame
    void Update()
    {
        // check if all enemies are dead
        // if any enemies are still alive exit out of update method
        foreach(Enemy enemy in _enemies)
        {
            if (enemy != null)
                return;
        }
        Debug.Log("Enemy Killed!");
        // load next level
        _nextLevelIndex++;
        print("update invoked");
        string nextLevelName = "Level" + _nextLevelIndex;
        SceneManager.LoadScene(nextLevelName);
    }
}
