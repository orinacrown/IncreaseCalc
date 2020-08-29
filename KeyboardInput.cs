/************************************************
 *                                              *
 * Class Name   : Keyboard Input                *
 * Super Class  :                               *
 * Author       : orinacrown                    *
 * Create day   : 2020/05/01                    *
 * Update day   :                               *
 *                                              *
 ************************************************/


/*  Use libraries       */

using UnityEngine;
using System.Collections;

/*  Class               */
public class KeyboardInput
{
    /*  Constant Fields     */


    /*  Read Only Fields    */
    private readonly string inputString = "0123456789";

    
    /*  Variable Fields     */
    private int outputCode;                   /*  入力による方向      */

    /*  Constructor         */
    public KeyboardInput()
    {

    }

    /*  Methods             */

    public void UpdateKeyBoardInput()
    {
        for(int i = 0; i < 10; i++)
        {
            if (Input.GetKeyDown(KeyCode.Keypad0 + i) || Input.GetKeyDown(inputString[i].ToString()))
            {
                outputCode = i;
                return;
            }
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            outputCode = 10;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            outputCode = 11;
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            outputCode = 12;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            outputCode = 13;
            return;
        }
        outputCode = -1;
    }

    public int GetOutputCode()
    {
        return outputCode;
    }

}
