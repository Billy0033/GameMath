using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsChooiser : MonoBehaviour
{
    public int easy_reward = 50;
    public int medium_reward = 75;
    public int hard_reward = 100;
    public QuestionObject[][] ChooiseQuestions(QuestionObject[][] questions, int easyQuestionsCount, int mediumQuestionsCount, int hardQuestionsCount)
    {
        QuestionObject[][] res = new QuestionObject[3][];
        res[0] = GetRandomQuestions(questions[0], easyQuestionsCount);
        for (int i = 0; i < res[0].Length; i++)
        {
            res[0][i].reward = easy_reward;
        }
        res[1] = GetRandomQuestions(questions[1], mediumQuestionsCount);
        for (int i = 0; i < res[1].Length; i++)
        {
            res[1][i].reward = medium_reward;
        }
        res[2] = GetRandomQuestions(questions[2], hardQuestionsCount);
        for (int i = 0; i < res[2].Length; i++)
        {
            res[2][i].reward = hard_reward;
        }
        return res;
    }
    QuestionObject[] GetRandomQuestions(QuestionObject[] questions, int count)
    {
        QuestionObject[] tmp = new QuestionObject[questions.Length];
        for(int i = 0; i < questions.Length; i++)
        {
            tmp[i] = questions[i];
        }
        QuestionObject[] res = new QuestionObject[count];
        int left = count;
        for (int i = 0;i<count;i++)
        {
            int select = Random.Range(0, left);
            //Debug.Log(select);
            res[i] = tmp[select];
            tmp[select] = tmp[tmp.Length - i - 1];
            left--;
        }
        return res;
    }
}
