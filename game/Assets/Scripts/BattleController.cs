using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    public Color correctAnswerColor;
    public Color wrongAnswerColor;
    public Color neutralAnswerColor;

    public static BattleController battleController;
    Database.Question question;

    public Text questionText;
    public Text[] answers;

    public GameObject mob;
    public GameObject boss;
    public GameObject deadMob;
    public GameObject deadBoss;

    int enemyLivesRemaining = 3;
    public SpriteRenderer enemyLivesSprite;

    public int playerLivesRemaining = 3;
    public SpriteRenderer playerLivesSprite;

    public GameObject continueButton;

    private Sprite[] spriteArray;
    private bool againstBoss;
    private bool waiting;

    void Start()
    {
        battleController = this;
        gameObject.SetActive(false);  
        spriteArray = Resources.LoadAll<Sprite>("lives");

        playerLivesSprite.sprite = spriteArray[3];
    }

    public void SelectAnswer(int ans){
        if(waiting) return;

        if(ans == question.correctAnswer){
            enemyLivesRemaining --;
            if(againstBoss)
                enemyLivesSprite.sprite = spriteArray[enemyLivesRemaining];
            else
                enemyLivesSprite.sprite = spriteArray[4];
            if(enemyLivesRemaining == 0){
                if(againstBoss) { boss.SetActive(false); deadBoss.SetActive(true); }
                else {mob.SetActive(false); deadMob.SetActive(true); }
            }

            StartCoroutine(WaitForAMoment());
        }
        else{
            playerLivesRemaining --;
            playerLivesSprite.sprite = spriteArray[playerLivesRemaining];

            StartCoroutine(WaitForButtonPress());
        }

        answers[ans].color = wrongAnswerColor;
        answers[question.correctAnswer].color = correctAnswerColor;


    }

    IEnumerator WaitForButtonPress(){
        waiting = true;
        float time = Time.time;
        continueButton.SetActive(true);
        while(waiting) yield return null;

        GameController.gameController.startTime += Time.time - time;
        Continue();
    }

    IEnumerator WaitForAMoment(){
        yield return new WaitForSeconds(1.5f);
        Continue();
    }

    private void Continue(){
         if(enemyLivesRemaining == 0 || playerLivesRemaining == 0){
            gameObject.SetActive(false);  
            GameController.gameController.EndBattle(playerLivesRemaining != 0);
        } else 
            nextQuestion();
    }

    public void ContinueButtonPress(){
        waiting = false;
    }

    public void StartBattle(bool boss){
        gameObject.SetActive(true);  

        againstBoss = boss;
        
        if(boss){
            this.boss.SetActive(true);
            this.mob .SetActive(false);
            deadMob.SetActive(false);
            deadBoss.SetActive(false);
            enemyLivesSprite.sprite = spriteArray[3];
            enemyLivesRemaining = 3;
        } else {
            this.boss.SetActive(false);
            this.mob .SetActive(true);
            deadMob.SetActive(false);
            deadBoss.SetActive(false);
            enemyLivesSprite.sprite = spriteArray[5];
            enemyLivesRemaining = 1;
        }

        nextQuestion();
    }

    void nextQuestion(){
        continueButton.SetActive(false);
        
        question = Database.database.GetQuestion(againstBoss, enemyLivesRemaining);

        questionText.text = question.question;
        answers[0].text = question.answer;
        answers[1].text = question.wanswer1;
        answers[2].text = question.wanswer2;
        answers[3].text = question.wanswer3;  

        if(againstBoss) questionText.text = "Dragon says: \"" +question.question + "\"";
        else questionText.text = "Snake says: \"" +question.question + "\"";

        foreach (var it in answers)
            it.color = neutralAnswerColor;   
  
    }
}
