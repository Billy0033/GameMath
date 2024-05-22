using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class QuestionObject
{
    //Картинка - то есть вопрос
    //Ответ - текст
}*/

public class GenerateVertex : MonoBehaviour
{
    public GameObject scene;
    public Transform startPos;
    public Transform endPos;
    public float rowHeight;
    public GameObject vertex;
    public GameObject edge;
    public float wholeWidth;
    // Start is called before the first frame update
    void Start()
    {
        /*QuestionObject[][] questions = new QuestionObject[3][];
        questions[0] = new QuestionObject[5];
        questions[1] = new QuestionObject[4];
        questions[2] = new QuestionObject[2];
        Generate(questions);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject[] Generate(QuestionObject[][] questions){
        List<GameObject> allVertexes = new List<GameObject>();
        int lines_num = questions.Length;
        for (int i=0;i<lines_num; i++)
        {
            GenerateLine(allVertexes,questions[i],-(i-(lines_num/2)));
        }
        return allVertexes.ToArray();
    }

    void GenerateLine(List<GameObject> list, QuestionObject[] questions, int index)
    {
        QuestionVertex lastVertexObj = null;
        int questions_count = questions.Length;
        float width = wholeWidth / questions_count;
        for(int i=0;i<questions_count;i++)
        {
            Vector3 center = (startPos.position + endPos.position) / 2;
            float x = width * (i - (questions_count / 2));
            if (questions_count % 2 == 0)
                x += width/2;
            float y = rowHeight * index;
            GameObject vertexObj = Instantiate(vertex, center + new Vector3(x,y,0),transform.rotation);
            list.Add(vertexObj);
            vertexObj.transform.parent = scene.transform;
            QuestionVertex question = vertexObj.GetComponent<QuestionVertex>();
            question.question = questions[i];
            question.answer = questions[i].answer;
            question.reward = questions[i].reward;
            if (lastVertexObj!=null)
            {
                lastVertexObj.nextQuestion = question;
                DrawEdge(list, vertexObj, lastVertexObj.gameObject);
            }
            else
            {
                DrawEdge(list, vertexObj, startPos.gameObject);
            }
            lastVertexObj = question;
        }
        DrawEdge(list, endPos.gameObject, lastVertexObj.gameObject);
    }
    void DrawEdge(List<GameObject> list, GameObject start, GameObject finish)
    {
        GameObject edgeObj = Instantiate(edge, (start.transform.position + finish.transform.position) / 2, transform.rotation);
        list.Add(edgeObj);
        edgeObj.transform.parent = scene.transform;
        float distance = Vector3.Distance(start.transform.position, finish.transform.position);
        Vector3 scale = edgeObj.transform.localScale;
        scale.x = distance;
        edgeObj.transform.localScale = scale;
        Vector3 direction = finish.transform.position - start.transform.position;
        direction.z = 0f;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        edgeObj.transform.rotation = rotation;
        //edgeObj.transform.LookAt(finish.transform.position);
        //edgeObj.transform.rotation.SetFromToRotation(start.transform.position, finish.transform.position);
    }
}
