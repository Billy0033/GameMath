using UnityEngine;
using System.IO;


// Класс для хранения информации о вопросе
public class QuestionObject
{
    public Texture2D image;
    public string answer;
    public int reward;
}

public class QuestionLoader : MonoBehaviour
{
    // Путь к папке с вопросами
    public string questionsFolderPath;
    public GenerateVertex generator;
    public PlayerMove player;
    public QuestionsChooiser questionsChooiser;

    // Массив для хранения вопросов из каждой подпапки
    private QuestionObject[][] SelectedQuestions;
    private QuestionObject[][] questions;
    private GameObject[] allVertexes;

    void Start()
    {
    }
    public void OrderStartGame(int easyQuestionsCount, int mediumQuestionsCount, int hardQuestionsCount)
    {
        LoadData();
        SelectQuestions(easyQuestionsCount, mediumQuestionsCount, hardQuestionsCount);
        SendData();
        LoadPlayerData();
    }
    public void OrderStopGame()
    {
        SetPlayerToStartLocation();
        DeleteAllVertexes();
    }
    void DeleteAllVertexes()
    {
        if(allVertexes != null)
            foreach (var vertex in allVertexes)
            {
                if (vertex != null)
                {
                    Destroy(vertex);
                }
            }
    }
    void SetPlayerToStartLocation()
    {
        player.transform.position = player.startVertex.transform.position;
        player.currentVertex = player.startVertex;
        player.target = player.startVertex.transform;
        
    }
    void SendData()
    {
        allVertexes = generator.Generate(SelectedQuestions);
    }
    void SelectQuestions(int easyQuestionsCount, int mediumQuestionsCount, int hardQuestionsCount)
    {
        SelectedQuestions = questionsChooiser.ChooiseQuestions(questions, easyQuestionsCount, mediumQuestionsCount, hardQuestionsCount);
    }
    void LoadData()
    {
        // Получаем список подпапок в указанной директории
        string[] subfolders = Directory.GetDirectories(questionsFolderPath);

        // Инициализируем массив для хранения вопросов
        questions = new QuestionObject[subfolders.Length][];

        // Проходимся по каждой подпапке
        for (int i = 0; i < subfolders.Length; i++)
        {
            // Получаем список файлов в текущей подпапке
            string[] files = Directory.GetFiles(subfolders[i]);
            int file_count = 0;

            //Debug.Log(files.Length);
            foreach (string file in files)
            {
                if(Path.GetExtension(file).ToLower() != ".meta")
                    file_count++;
            }
            //Debug.Log(files.Length);
            // Инициализируем массив для хранения вопросов текущей подпапки
            questions[i] = new QuestionObject[file_count/2]; // Предполагаем, что файлов с изображениями и текстовыми файлами одинаковое количество

            // Проходимся по каждой паре файлов (изображение и текстовый файл)
            int question_number = 0;
            for (int j = 0; j < files.Length; j++)
            {
                //Debug.Log(Path.GetExtension(files[j]).ToLower());
                if (Path.GetExtension(files[j]).ToLower() == ".meta" || Path.GetExtension(files[j]).ToLower() == ".txt")
                    continue;
                if (Path.GetExtension(files[j]).ToLower() == ".png" || Path.GetExtension(files[j]).ToLower() == ".jpg")
                {
                    // Создаем экземпляр вопроса
                    QuestionObject question = new QuestionObject();

                    // Загружаем изображение
                    byte[] fileData = File.ReadAllBytes(files[j]);
                    Texture2D texture = new Texture2D(2, 2);
                    texture.LoadImage(fileData);
                    question.image = texture;

                    // Загружаем текстовый файл
                    foreach(string text_file in files)
                    {
                        if (Path.GetExtension(text_file).ToLower() == ".txt" && Path.GetFileNameWithoutExtension(text_file).ToLower() == Path.GetFileNameWithoutExtension(files[j]).ToLower())
                        {
                            question.answer = File.ReadAllText(text_file);
                            //Debug.Log(question.answer);
                        }
                    }
                    questions[i][question_number] = question;
                    question_number++;
                }
            }
        }



        // Теперь в переменной questions у вас массив, содержащий все вопросы из каждой подпапки.
        // Можете использовать его по своему усмотрению.
    }

    void LoadPlayerData()
    {
        QuestionObject[] firstQuestionVertexes = new QuestionObject[SelectedQuestions.Length];
        for(int i = 0; i < firstQuestionVertexes.Length; i++)
        {
            firstQuestionVertexes[i] = SelectedQuestions[i][0];
        }
        player.firstQuestionVertexes = firstQuestionVertexes;


    }
}
