using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// controls the button in menu
public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    // to set which character to choose get which button is pressed
    public void playGame() {
        // for getting which button is pressed
        int clickedObject = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        GameManager.instance.charIndex = clickedObject;
        SceneManager.LoadScene("GamePlay");
    }
}
