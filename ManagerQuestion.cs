using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
//using System.Globalization.NumberStyles;

public class ManagerQuestion : MonoBehaviour
{
    public StartScript controlScript;
    public static ManagerQuestion Instance;
    public CoinManager coinManager;
    public HealthPanel healthPanel;
    public GameObject questionPanel;
    public Button commitButton;
    public GameObject ratioIntAnswerPanel;
    public GameObject ratioAnswerPanel;
    public GameObject decimalAnswerPanel;
    public TMP_InputField decimanAnswer;
    public TMP_InputField integerAnswer;
    public TMP_InputField nominatorIntAnswer;
    public TMP_InputField demoninatorIntAnswer;
    public TMP_InputField nominatorAnswer;
    public TMP_InputField demoninatorAnswer;
    public RawImage questionImage;
    public Button backButton;
    public int questionType;
    public string[] answers;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowQuestion(QuestionObject question)
    {
        ClearInput();
        PlayerMove.Instance.active_question = true;
        if (question == null)
            return;
        questionImage.texture = question.image;
        answers = RemoveEmptyLines(question.answer.Split("\n"));
        if (answers.Length == 1)
        {
            questionType = 1;
            decimalAnswerPanel.SetActive(true);
            ratioAnswerPanel.SetActive(false);
            ratioIntAnswerPanel.SetActive(false);
        }
        else if (answers.Length == 2)
        {
            decimalAnswerPanel.SetActive(false);
            ratioAnswerPanel.SetActive(true);
            ratioIntAnswerPanel.SetActive(false);
            questionType = 2;
        }
        else
        {
            questionType = 3;
            decimalAnswerPanel.SetActive(false);
            ratioAnswerPanel.SetActive(false);
            ratioIntAnswerPanel.SetActive(true);
        }
        questionPanel.SetActive(true);
    }
    void ClearInput()
    {
        decimanAnswer.text = "";
        integerAnswer.text = "";
        nominatorIntAnswer.text = "";
        demoninatorIntAnswer.text = "";
        nominatorAnswer.text = "";
        demoninatorAnswer.text = "";
    }
    public void FinishGame()
    {
        controlScript.EndGame();
    }
    public void CommitButtonClick()
    {
        if (CheckAnswer())
        {
            PassAnswer();
        }
        else
        {
            FailAnswer();
        }
    }
    public void BackButtonClick()
    {
        GoBack();
    }

    void PassAnswer()
    {
        AddCoins();
        questionPanel.SetActive(false);
        PlayerMove.Instance.active_question = false;
        PlayerMove.Instance.currentVertex.SetSuccess();
    }

    void FailAnswer()
    {
        PlayerMove.Instance.currentVertex.SetFailed();
        LooseLife();
        GoBack();
    }

    void LooseLife()
    {
        healthPanel.lives--;
        if(healthPanel.lives <= 0)
        {
            controlScript.FailGame();
        }
    }

    void AddCoins()
    {
        coinManager.coins += PlayerMove.Instance.currentVertex.reward;
    }

    public void GoBack()
    {
        questionPanel.SetActive(false);
        PlayerMove.Instance.active_question = false;
        if(PlayerMove.Instance.lastVertex != null)
            PlayerMove.Instance.GoTo(PlayerMove.Instance.lastVertex);
        else
            PlayerMove.Instance.GoTo(PlayerMove.Instance.startVertex);
    }

    bool CheckAnswer()
    {
        if(questionType == 1)
        {
            if(CompareFloats(decimanAnswer.text,answers[0]))
                return true;
        }
        else if(questionType == 3)
        {
            if(CompareFloats(integerAnswer.text,answers[0]) && CompareFloats(nominatorIntAnswer.text,answers[1]) && CompareFloats(demoninatorIntAnswer.text, answers[2]))
            {
                return true;
            }
        }else if(questionType == 2)
        {
            if (CompareFloats(nominatorAnswer.text, answers[0]) && CompareFloats(demoninatorAnswer.text, answers[1]))
            {
                return true;
            }
        }
        return false;
    }

    bool CompareFloats(string a, string b)
    {
        //Debug.Log(a+ "|" + b);
        a = a.Replace(".", ",");
        b = b.Replace(".", ",");
        float a2 = float.Parse(a, System.Globalization.NumberStyles.Float);
        float b2 = float.Parse(b, System.Globalization.NumberStyles.Float);
        return a2 == b2;
    }

    public static string[] RemoveEmptyLines(string[] lines)
    {
        return lines.Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();
    }
}
