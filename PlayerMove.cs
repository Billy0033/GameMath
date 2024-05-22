using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float minDistance=0.01f;
    public bool is_walking = false;
    public bool active_question = false;
    public QuestionVertex startVertex;
    public QuestionVertex lastVertex;
    public QuestionVertex finishVertex;
    public QuestionVertex currentVertex;
    public QuestionObject[] firstQuestionVertexes;
    public static PlayerMove Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(target == null)
        {
            return;
        }
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance > minDistance)
        {
            Vector3 vec = target.position - transform.position;
            Vector3 vec1 = vec.normalized;
            transform.position = transform.position + vec1 * speed * Time.deltaTime;
        }
        else if (is_walking)
        {
            is_walking = false;
            Arrive();
        }
    }

    void Arrive()
    {
        QuestionVertex new_current = target.gameObject.GetComponent<QuestionVertex>();
        lastVertex = currentVertex;
        currentVertex = new_current;
        if(new_current.question!=null && !new_current.answered)
        {
            ManagerQuestion.Instance.ShowQuestion(new_current.question);
        }
        else if(new_current == finishVertex)
        {
            ManagerQuestion.Instance.FinishGame();
        }
    }

    public void tryToMove(QuestionVertex questionVertex)
    {
        if(currentVertex == startVertex)
        {
            bool tmp = false;
            foreach(var question in firstQuestionVertexes)
            {
                if(questionVertex.question == question)
                {
                    tmp = true;
                    break;
                }
            }
            if(tmp)
            {
                GoTo(questionVertex);
            }

        }
        else if(currentVertex.nextQuestion != null)
        {
            if(questionVertex == currentVertex.nextQuestion)
            {
                GoTo(currentVertex.nextQuestion);
            }
        }
        else
        {
            if(questionVertex == finishVertex)
            {
                GoTo(finishVertex);
            }
        }
    }
    public void GoTo(QuestionVertex questionVertex)
    {
        if (!is_walking && !active_question)
        {
            target = questionVertex.transform;
            is_walking = true;
        }
    }
}
