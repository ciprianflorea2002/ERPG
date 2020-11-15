using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public static StartScreen startScreen;
    public Text code;
    public Text username;
    public Text error;

    void Start(){
        startScreen = this;
        gameObject.SetActive(true);
    }

    public void StartGame(){
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame(){

        if(username.text == "" || code.text == "")
            error.text = "Game code and username can not be empty";
        else{
            bool exists = false;
            yield return Database.database.CheckGame(code.text);

            if(!Database.database.exists)
                error.text = "Game does not exists";
            else{
                Database.database.LoadGame(code.text);
                gameObject.SetActive(false);

                GameController.gameController.StartGame();
            }
        }
    }
}
