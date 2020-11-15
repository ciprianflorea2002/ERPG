using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public static EndScreen endScreen;
    public GameObject lost;
    public GameObject won;
    public Text score;
    void Start()
    {
        endScreen = this;
        gameObject.SetActive(false);
    }

    public void End(bool _won, int _score){
        gameObject.SetActive(true);
        lost.SetActive(!_won);
        won.SetActive(_won);
        score.text = "score: " + _score;
        StartCoroutine(Database.database.PostScore(StartScreen.startScreen.code.text,
                                StartScreen.startScreen.username.text, _score));

        if(!_won)
            PlayerAnimator.SetAnimation(PlayerAnimator.dyingAnimation);
    }
}
