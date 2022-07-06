using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextScript : MonoBehaviour
{
    static Stack<int> col = new Stack<int>();
    static Stack<int> lin = new Stack<int>();
    static Stack<string> fl = new Stack<string>();
    private static int counter = 0;
    public int linie, coloana;
    public string file;
    private static int[,] board = new int[3, 3];
    private static bool endgame = false;
    public static void MoveBack()
    {
        if(counter > 0)
        {
            counter--;
            GameObject.Find("Player text").GetComponent<TMP_Text>().text = "Player" + (counter % 2 + 1) + "  Hai gogule, e randul tau";
            GameObject.Find("Replay text").GetComponent<TMP_Text>().text = "";
            GameObject.Find("Win text").GetComponent<TMP_Text>().text = "";
            int l = lin.Peek();
            int c = col.Peek();
            string f = fl.Peek();
            if(endgame == true)
            {
                Debug.Log("NVM, Se continua meciul");
                endgame = false;
            }
            
            board[l, c] = 0;
            fl.Pop();
            lin.Pop();
            col.Pop();
            GameObject.Find(f).GetComponent<TMP_Text>().text = "";
        }
    } 
    public static void ResetGame()
    {
        counter = 0;
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = 0;
            }
    }
    public void GameOver()
    {
        GameObject.Find("Win text").GetComponent<TMP_Text>().text = "END OF THE GAME";
        GameObject.Find("Replay text").GetComponent<TMP_Text>().text = "Reply";
        GameObject.Find("Player text").GetComponent<TMP_Text>().text = "Mai baga o fisa GOGULE, player " + (counter % 2 + 1) + " CASTIGA";
        GameObject.Find("TEXT").GetComponent<TMP_Text>().text = "";
        GameObject.Find("Counter text").GetComponent<TMP_Text>().text = "";

    }

    
    private bool CheckWin(int player)
    {
        
        if (board[0, 0] == player && board[0, 1] == player && board[0, 2] == player) 
             return true; 
        if (board[1, 0] == player && board[1, 1] == player && board[1, 2] == player) 
            return true; 
        if (board[2, 0] == player && board[2, 1] == player && board[2, 2] == player)  
            return true; 

        if (board[0, 0] == player && board[1, 0] == player && board[2, 0] == player) 
            return true; 
        if (board[0, 1] == player && board[1, 1] == player && board[2, 1] == player) 
            return true; 
        if (board[0, 2] == player && board[1, 2] == player && board[2, 2] == player) 
            return true; 

        if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) 
            return true; 
        if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player) 
            return true; 
        return false;
    }
    void OnMouseDown()
    {
        if (board[linie, coloana] == 0 && endgame == false)
        {
            GetComponent<TMP_Text>().text = counter % 2 == 0 ? "X" : "0";
            counter++;
            board[linie, coloana] = counter % 2 + 1;
            GameObject.Find("Player text").GetComponent<TMP_Text>().text = "Player" + (counter % 2 + 1) + "  Hai gogule, e randul tau";
            col.Push(coloana);
            lin.Push(linie);
            fl.Push(file);
            bool win1 = CheckWin(1);
            bool win2 = CheckWin(2);
            //Debug.Log(counter);
            if (win1 && endgame == false)
            {
                Debug.Log("Player 1 a castigat");
                endgame = true;
                GameOver();
            }

            if (win2 && endgame == false)
            {
                endgame = true;
                Debug.Log("Player 2 a castigat");
                GameOver();
            }

            if (counter == 9 && endgame == false)
            {
                endgame = true; ;
                Debug.Log("DRAW");
                GameOver();
            }
        }
        else
        {
            if (endgame)
                Debug.Log("Meciul s-a terminat");
            else if(board[linie, coloana] > 0)
                Debug.Log("Caseta nu este libera!!!");
        }
            
    }
}
