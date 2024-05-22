using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionVertex : MonoBehaviour
{
    public QuestionVertex nextQuestion;
    public QuestionObject question;
    public Sprite normalTexture;
    public Sprite failedTexture;
    public Sprite successTexture;
    SpriteRenderer sprite;
    public string answer;
    public bool answered = false;
    public int reward = 50;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        //ManagerQuestion.Instance.ShowQuestion(question);


        GameObject player = GameObject.FindWithTag("Player");
        PlayerMove move = player.GetComponent<PlayerMove>();
        move.tryToMove(this);
        //move.target = transform;
    }

    public void SetFailed()
    {
        sprite.sprite = failedTexture;
    }

    public void SetSuccess()
    {
        sprite.sprite = successTexture;
        answered = true;
    }

    public void SetNormal()
    {
        sprite.sprite = normalTexture;
    }

}
