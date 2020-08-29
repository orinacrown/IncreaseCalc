/************************************************
 *                                              *
 * Class Name   : GameManager                   *
 * Super Class  : Monobehaviour                 *
 * Author       : orinacrown                    *
 * Create day   : 2020/05/01                    *
 * Update day   :                               *
 *                                              *
 ************************************************/

/*  Use libraries           */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*  Class                   */
public class Answer
{
    /*  Static Arguments        */

    /*  Constant Arguments      */
    private const int NULL_CODE = -1;
    private const int BACK_CODE = 10;
    private const int ENTER_CODE = 11;

    /*  Constructor Arguments   */
    private readonly int correctAnswer;
    /*  Read Only Arguments     */
    
    
    /*  Variable Arguments      */
    private int inputAnswer;

    /*  Constructor             */
    public Answer(int correctAnswer)
    {
        inputAnswer = 0;
        this.correctAnswer = correctAnswer;
    }

    /*  Methods                 */
    public void AnswerInput(int code)
    {
        if (code == NULL_CODE)
        {
            return;
        }
        if (code == BACK_CODE)
        {
            inputAnswer /= 10;
            return;
        }
        inputAnswer = inputAnswer * 10 + code;
        return;
    }

    public bool IsCorrect()
    {
        bool correct = (inputAnswer == correctAnswer);
        inputAnswer = 0;
        return correct;
    }

    public int GetCorrectAnswer()
    {
        return correctAnswer;
    }

    public int GetInputAnswer()
    {
        return inputAnswer;
    }
}
