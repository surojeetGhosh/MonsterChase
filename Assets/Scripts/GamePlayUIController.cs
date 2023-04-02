using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// since gameManager never get destroyed every information is retained
//SceneManager .GetActiveScene().name for current scene name in restart
public class GamePlayUIController : MonoBehaviour
{
    // Start is called before the first frame update
    public void restart() {
        SceneManager.LoadScene("GamePlay");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void home() {
        SceneManager.LoadScene("Menu");
    }
}
