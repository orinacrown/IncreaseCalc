/************************************************
 *                                              *
 * Class Name   : GameManager                   *
 * Super Class  : Monobehaviour                 *
 * Author       : orinacrown                    *
 * Create day   : 2020/05/01                    *
 * Update day   : 2020/08/10                    *
 *                                              *
 ************************************************/


/*  Use libraries       */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*  Class               */
public class GameManager : MonoBehaviour
{

    /*  Constant Arguments      */
    private const int gameTimeSec = 30;
    private const int SecToMS = 1000;
    
    /*  Variable Arguments      */
    private KeyboardInput keyboardInput;
    private Answer answer;
    private GameTimer gameTimer;
    private Score score;
    private int level;


    /*  UnityEditor Components  */
    private AudioSource audioSource;
    /*  Unity Editor Arguments  */
    public GameObject endGong;
    public Text timeText;
    public Text answerText;
    public Text questionText;
    public AudioClip correctClip;
    public AudioClip wrongClip;
    public AudioClip levelResetClip;
    public AfterImageEffect questionEffect;
    public AfterImageEffect answerEffect;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        score = new Score();

        keyboardInput = new KeyboardInput();
        gameTimer = new GameTimer(gameTimeSec * SecToMS);
        ResetAnswer();
        NewQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameTimer.IsTimeOver())
        {
            timeText.text = "0";
            GameEnd();
            return;
        }
        int timeLimit = gameTimer.RemainingTimeMS() / SecToMS + 1;
        timeText.text = timeLimit.ToString();
        float timerColor = (float)timeLimit / gameTimeSec;
        timeText.color = new Color(1, timerColor, timerColor);
        keyboardInput.UpdateKeyBoardInput();
        int inputCode = keyboardInput.GetOutputCode();
        if (inputCode == -1)
        {
            return;
        }
        if (inputCode == 11)
        {
            if (answer.IsCorrect() == true)
            {
                score.Correct(++level);
                answerEffect.Correct();
                if (Score.CurrentScore() % 5 == 0)
                {
                    gameTimer.CorrectBonus();
                }
                audioSource.PlayOneShot(correctClip);
                NewQuestion();
                return;
            }
            answerEffect.Wrong();
            gameTimer.WrongAnswer();
            audioSource.PlayOneShot(wrongClip);
            answerText.text = "";
            answer = new Answer(answer.GetCorrectAnswer());
            return;
        }
        if (inputCode == 10)
        {
            if (answer.GetInputAnswer() == 0)
            {
                return;
            }
            answer.AnswerInput(inputCode);
            answerText.text = $"{answer.GetInputAnswer()}";
            return;
        }
        if (inputCode == 12)
        {
            for(int i = 0; i < gameTimeSec; i++)
            {
                gameTimer.WrongAnswer();
            }
            return;
        }
        if (inputCode == 13)
        {
            answerEffect.QuestionReset();
            questionEffect.QuestionReset();
            ResetAnswer();
            NewQuestion();
            audioSource.PlayOneShot(levelResetClip);
            return;
        }
        answer.AnswerInput(inputCode);
        answerText.text = $"{answer.GetInputAnswer()}";
    }

    private void NewQuestion()
    {
        int tern = Random.Range(2, 10);
        int oldAnswer = answer.GetCorrectAnswer();
        int correctAnswer = tern * oldAnswer;
        answer = new Answer(correctAnswer);
        questionText.text = $"{oldAnswer} × {tern}";
        answerText.text = "";
    }

    private void GameEnd()
    {
        if (audioSource.isPlaying == false)
        {
            return;
        }
        audioSource.Stop();
        Instantiate(endGong);
    }

    private void ResetAnswer()
    {
        level = 0;
        answer = new Answer(Random.Range(2, 10));
    }

}
