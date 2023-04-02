using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// spawn players based on information
public class GameManager : MonoBehaviour
{
    // this is for fetching the value of gamemanager created
    public static GameManager instance;
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] players;

    private int _charIndex;

    public int charIndex {
        get { return _charIndex; }
        set { _charIndex = value; }
    }

    // this is singleton pattern which means for an instance there will be only one GameManager.instance
    // singleton patter lets only one gameObject in a scene which comes from previous,
    private void Awake() {
        if(instance == null) {
            // for not destroying object when scene switching
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // Events and Delegates
    /*
        delegates are functions which emits events
        events are used to subscribe to listen delegates
        it wll run all the functions which is subscribed for the event
    
    */
    // subscribe
    private void OnEnable() {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    //unsubscribe
    private void OnDisable() {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    // this event will be called first when scene loaded
    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
        if(scene.name == "GamePlay") {
            Instantiate(players[charIndex]);
        }
    }
}
