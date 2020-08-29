/************************************************
 *                                              *
 * Class Name   : GameTimer                     *
 * Super Class  :                               *
 * Author       : orinacrown                    *
 * Create day   : 2020/05/01                    *
 * Update day   :                               *
 *                                              *
 ************************************************/

/*  Use libraries           */
using UnityEngine;
using System.Collections;

/*  Class                   */
public class GameTimer
{
    /*  Static Arguments        */

    /*  Constant Arguments      */
    
    /*  Constructor Arguments   */
    private readonly int gameTimeMS;
    
    /*  Read Only Arguments     */
    private TimeFlagger timeFlagger;
    /*  Variable Arguments      */
    private int offsetMS;
    /*  Constructor             */
    public GameTimer(int gameTimeMS)
    {
        timeFlagger = new TimeFlagger(gameTimeMS);
        offsetMS = 0;
        this.gameTimeMS = gameTimeMS;
    }
    /*  Methods                 */

    public bool IsTimeOver()
    {
        return timeFlagger.IsTimeOverOffset(offsetMS);
    }

    public void WrongAnswer()
    {
        offsetMS += 1000;
    }

    public void CorrectBonus()
    {
        offsetMS -= 1000;
    }

    public int RemainingTimeMS()
    {
        int pastTime = timeFlagger.PastTimeMS();
        int remainingTime = pastTime - offsetMS;
        return remainingTime;
    }
}
