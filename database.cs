using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class database : MonoBehaviour
{
    private string questions;
    
    private int[] indices = {0,1,2,3}; 
    
    public struct Question 
    {
        private static int[] indices = {0,1,2,3}; 
        public string question;
        public int difficulty;
        public string answer;
        public string wanswer1;
        public string wanswer2;
        public string wanswer3;
        public int correctAnswer;
        public void Shuffle()
        {
            string ans = answer;
            List<string> answers = new List<string>(){answer,wanswer1,wanswer2,wanswer3};
            indices.Shuffle();
            List<string> answersPerm = new List<string>(){answers[indices[0]],answers[indices[1]],answers[indices[2]],answers[indices[3]]};
            for (int i = 0; i <=3; i++)
            {
                if (ans == answersPerm[i]) 
                {
                    correctAnswer = i+1;
                    break;
                }
            }
            answer = answersPerm[0];
            wanswer1 = answersPerm[1];
            wanswer2 = answersPerm[2];
            wanswer3 = answersPerm[3];
        }
    }

    public List<Question> questionarray;
    public List<Question> easyQuestions;
    public List<Question> mediumQuestions;
    public List<Question> hardQuestions;

    void Start()
    {
        easyQuestions = new List<Question>();
        mediumQuestions = new List<Question>();
        hardQuestions = new List<Question>();
        StartCoroutine(GetQuestions("http://localhost/UnityBackend/GetItems.php"));
        
    }

    IEnumerator GetQuestions(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                questions = webRequest.downloadHandler.text; 
                questionarray = JsonConvert.DeserializeObject<List<Question>>(questions);
                // Debug.Log(questionarray.Count);
                foreach (var item in questionarray)
                {
                    item.Shuffle();
                    if (item.difficulty <= 4) easyQuestions.Add(item);
                    else if (item.difficulty <=7) mediumQuestions.Add(item);
                    else hardQuestions.Add(item);
                }


                // Debug.Log(GetQ(true,2).question);
            }
        }
    }

    
    
    public Question GetRandomEasyQ()
    {
        int r = Random.Range(0,easyQuestions.Count);
            return easyQuestions[r];
    }
    
    public Question GetRandomMediumQ()
    {
        int r = Random.Range(0,mediumQuestions.Count);
            return mediumQuestions[r];
    }

    public Question GetRandomHardQ()
    {
        int r = Random.Range(0,hardQuestions.Count);
            return hardQuestions[r];
    }

    public Question GetQ(bool isBoss, int lives)
    {
        Question Q;
        if (!isBoss) //is mob
        {
            Q = GetRandomEasyQ();
            easyQuestions.Remove(Q);
            return Q;
        }
        else //is boss
        {
            if (lives == 1) 
            {
                Q = GetRandomHardQ();
                hardQuestions.Remove(Q);
                return Q;
            }            
            if (lives == 2) 
            {
                Q = GetRandomMediumQ();
                mediumQuestions.Remove(Q);
                return Q;
            }  
            if (lives == 3)
            {
                Q = GetRandomEasyQ();
                easyQuestions.Remove(Q);
                return Q;
            }
        }
        return new Question();
   }
}
