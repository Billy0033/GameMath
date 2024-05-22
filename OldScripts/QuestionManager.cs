using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Threading;

[System.Serializable]
public class Question
{
    public string questionText;
    public string correctAnswer;
}

public class QuestionManager : MonoBehaviour
{
    public GameObject questionPanel;
    public Text questionText;
    public InputField answerInput;
    
    //public Sprite newSprite;
    //public GameObject TrueAnswer;
    //public GameObject FalseAnswer;

    private List<Question> questions = new List<Question>();
    private int currentQuestionIndex;

    void Start()
    {
        HideQuestionPanel();

        // Добавляем вопросы в список
        AddQuestion("2 - 2 = ?", "0");
        AddQuestion("2 * 5 = ?", "10");
        // Добавьте другие вопросы по аналогии
        ShowQuestionPanel();
    }

    public void AddQuestion(string questionText, string correctAnswer)
    {
        Question newQuestion = new Question();
        newQuestion.questionText = questionText;
        newQuestion.correctAnswer = correctAnswer;
        questions.Add(newQuestion);
    }

    public void ShowQuestionPanel()
    {
        questionPanel.SetActive(true);
        currentQuestionIndex = Random.Range(0, questions.Count);
        questionText.text = questions[currentQuestionIndex].questionText;
    }

    public void HideQuestionPanel()
    {
        //questionPanel.SetActive(false);
    }

    public void CheckAnswer()
    {
        string userAnswer = answerInput.text.Trim().ToLower();
        if (userAnswer == questions[currentQuestionIndex].correctAnswer.ToLower())
        {
            Debug.Log("Correct answer!");
            questionPanel.gameObject.SetActive(false);
            //obj.tag = "CircleOk";
            //SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            //if (spriteRenderer != null)
            //{
            //    // Меняем спрайт на новый
            //    spriteRenderer.sprite = newSprite;
            //}
        }

        else
        {
            Debug.Log("Wrong answer!");
            // Здесь можно уменьшить количество жизней и вернуться к предыдущему кругу
            //FalseAnswer.gameObject.SetActive(true);
            questionPanel.gameObject.SetActive(false);
            //FalseAnswer.gameObject.SetActive(false);
        }
    }

    public void backToGame()
    {
        questionPanel.gameObject.SetActive(false);
        //FalseAnswer.gameObject.SetActive(false);
        //TrueAnswer.gameObject.SetActive(false);

    }
}
