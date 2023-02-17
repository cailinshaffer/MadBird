using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    public void PlayAgainButton()
    {
        SceneManager.LoadScene("Level1");
        print("Play Again is working!");

    }
}
