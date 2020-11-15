using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    public static BattleController battleController;
    Database.Question question;

    public Text questionText;
    public Text answer1Text;
    public Text answer2Text;
    public Text answer3Text;
    public Text answer4Text;

    public GameObject mob;
    public GameObject boss;

    int enemyLivesRemaining = 3;
    public SpriteRenderer enemyLivesSprite;

    public int playerLivesRemaining = 3;
    public SpriteRenderer playerLivesSprite;

    private Sprite[] spriteArray;
    private bool againstBoss;

    void Start()
    {
        battleController = this;
        gameObject.SetActive(false);  
        spriteArray = Resources.LoadAll<Sprite>("lives");

        playerLivesSprite.sprite = spriteArray[3];
    }

    public void SelectAnswer(int ans){
        if(ans == question.correctAnswer){
            enemyLivesRemaining --;
            if(againstBoss)
                enemyLivesSprite.sprite = spriteArray[enemyLivesRemaining];
            else
                enemyLivesSprite.sprite = spriteArray[4];
        }
        else{
            playerLivesRemaining --;
            playerLivesSprite.sprite = spriteArray[playerLivesRemaining];
        }

        if(enemyLivesRemaining == 0 || playerLivesRemaining == 0){
            gameObject.SetActive(false);  
            GameController.gameController.EndBattle(playerLivesRemaining != 0);
            return;
        }

        nextQuestion();
    }

    public void StartBattle(bool boss){
        gameObject.SetActive(true);  

        againstBoss = boss;
        
        if(boss){
            this.boss.SetActive(true);
            this.mob .SetActive(false);
            enemyLivesSprite.sprite = spriteArray[3];
            enemyLivesRemaining = 3;
        } else {
            this.boss.SetActive(false);
            this.mob .SetActive(true);
            enemyLivesSprite.sprite = spriteArray[5];
            enemyLivesRemaining = 1;
        }

        nextQuestion();
    }

    void nextQuestion(){
        question = Database.database.GetQuestion(againstBoss, enemyLivesRemaining);

        questionText.text = question.question;
        answer1Text.text = question.answer;
        answer2Text.text = question.wanswer1;
        answer3Text.text = question.wanswer2;
        answer4Text.text = question.wanswer3;       
    }
}
