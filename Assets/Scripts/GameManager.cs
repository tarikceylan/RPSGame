using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{

    public GameObject winnerPanel, roundWinnerPanel;
    public GameObject winnerText, roundWinnerText;
    public GameObject youScoreText;
    public GameObject comScoreText;
    public GameObject getPointsText;
    public Sprite rockImage_L, rockImage_R, paperImage_L, paperImage_R, scissorsImage_L, scissorsImage_R;
    public GameObject comChar;
    public GameObject playerChar;



    public int playerChoice = -1;
    public int comChoice = -1;
    public bool playerTurn = true;




    enum choice { Rock, Paper, Scissors };


    void Update()
    {
        isPlayersTurn();
    }

    public void isPlayersTurn()
    {
        if (playerTurn == true)
        {
            return;
        }
        else if (playerTurn == false)
        {
            comChoose();
            checkRoundWinner();
            checkMatchWinner();
        }
    }


    public void playerChoose(int choice)
    {
        playerChoice = choice;
        playerTurn = false;

        if (playerChoice == 0)
        {
            playerChar.GetComponent<Image>().sprite = rockImage_L;
        }

        else if (playerChoice == 1)
        {
            playerChar.GetComponent<Image>().sprite = paperImage_L;
        }

        else if (playerChoice == 2)
        {
            playerChar.GetComponent<Image>().sprite = scissorsImage_L;
        }

    }


    public void comChoose()
    {
        playerChar.GetComponent<Animator>().enabled = true;
        comChar.GetComponent<Animator>().enabled = true;
        comChoice = UnityEngine.Random.Range(0, 3);
        playerTurn = true;

        if (comChoice == 0)
        {
            comChar.GetComponent<Image>().sprite = rockImage_R;
        }

        else if (comChoice == 1)
        {
            comChar.GetComponent<Image>().sprite = paperImage_R;
        }

        else if (comChoice == 2)
        {
            comChar.GetComponent<Image>().sprite = scissorsImage_R;
        }
    }

    public void startNextRound()
    {

        int comScore = Int32.Parse(comScoreText.GetComponent<TMPro.TextMeshProUGUI>().text);
        int youScore = Int32.Parse(youScoreText.GetComponent<TMPro.TextMeshProUGUI>().text);

        if (comScore != 3 || youScore != 3)
        {
            roundWinnerPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -1440);
            playerChar.GetComponent<Image>().sprite = rockImage_L;
            comChar.GetComponent<Image>().sprite = rockImage_R;
        }

        else
        {
            return;
        }

    
    }

    public void moveRoundPanel()
    {
        int comScore = Int32.Parse(comScoreText.GetComponent<TMPro.TextMeshProUGUI>().text);
        int youScore = Int32.Parse(youScoreText.GetComponent<TMPro.TextMeshProUGUI>().text);

        if (comScore != 3 || youScore != 3)
        {
            roundWinnerPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -1440);
            playerChar.GetComponent<Animator>().enabled = true;
            comChar.GetComponent<Animator>().enabled = true;
        }

        else
        {
            return;
        }
    }

    public void checkRoundWinner()
    {
        int comScore = Int32.Parse(comScoreText.GetComponent<TMPro.TextMeshProUGUI>().text);
        int youScore = Int32.Parse(youScoreText.GetComponent<TMPro.TextMeshProUGUI>().text);

        if (youScore == 3 || comScore == 3)
        {
            return;    
        }
            


        if (playerChoice == comChoice)
        {
            playerChar.GetComponent<Animator>().enabled = false;
            comChar.GetComponent<Animator>().enabled = false;
            roundWinnerPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            roundWinnerText.GetComponent<TMPro.TextMeshProUGUI>().text = "IT'S A DRAW!";
            return;
        }

        else if (playerChoice == (int)choice.Rock && comChoice == (int)choice.Paper)
        {
            //PLAYER ROCK - COM PAPER
            //COM Wins
            playerChar.GetComponent<Animator>().enabled = false;
            comChar.GetComponent<Animator>().enabled = false;
            roundWinnerPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            roundWinnerText.GetComponent<TMPro.TextMeshProUGUI>().text = "PAPER COVERS ROCK!";
            comScore += 1;
            comScoreText.GetComponent<TMPro.TextMeshProUGUI>().text = comScore.ToString();

        }

        else if (playerChoice == (int)choice.Rock && comChoice == (int)choice.Scissors)
        {
            //PLAYER ROCK - COM SCI
            //PLAYER Wins
            playerChar.GetComponent<Animator>().enabled = false;
            comChar.GetComponent<Animator>().enabled = false;
            roundWinnerPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            roundWinnerText.GetComponent<TMPro.TextMeshProUGUI>().text = "ROCK CRUSHES SCISSORS!";
            youScore += 1;
            youScoreText.GetComponent<TMPro.TextMeshProUGUI>().text = youScore.ToString();
        }

        else if (playerChoice == (int)choice.Paper && comChoice == (int)choice.Rock)
        {
            //PLAYER PAPER - COM ROCK
            //PLAYER Wins
            playerChar.GetComponent<Animator>().enabled = false;
            comChar.GetComponent<Animator>().enabled = false;
            roundWinnerPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            roundWinnerText.GetComponent<TMPro.TextMeshProUGUI>().text = "PAPER COVERS ROCK!";
            youScore += 1;
            youScoreText.GetComponent<TMPro.TextMeshProUGUI>().text = youScore.ToString();
        }

        else if (playerChoice == (int)choice.Paper && comChoice == (int)choice.Scissors)
        {
            //PLAYER PAPER - COM SCI
            //COM Wins
            playerChar.GetComponent<Animator>().enabled = false;
            comChar.GetComponent<Animator>().enabled = false;
            roundWinnerPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            roundWinnerText.GetComponent<TMPro.TextMeshProUGUI>().text = "SCISSORS CUTS PAPER!";
            comScore += 1;
            comScoreText.GetComponent<TMPro.TextMeshProUGUI>().text = comScore.ToString();
        }

        else if (playerChoice == (int)choice.Scissors && comChoice == (int)choice.Rock)
        {
            //PLAYER SCI - COM ROCK
            //COM Wins
            playerChar.GetComponent<Animator>().enabled = false;
            comChar.GetComponent<Animator>().enabled = false;
            roundWinnerPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            roundWinnerText.GetComponent<TMPro.TextMeshProUGUI>().text = "ROCK CRUSHES SCISSORS!";
            comScore += 1;
            comScoreText.GetComponent<TMPro.TextMeshProUGUI>().text = comScore.ToString();
        }

        else if (playerChoice == (int)choice.Scissors && comChoice == (int)choice.Paper)
        {
            //PLAYER PAPER - COM ROCK
            //PLAYER Wins
            playerChar.GetComponent<Animator>().enabled = false;
            comChar.GetComponent<Animator>().enabled = false;
            roundWinnerPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            roundWinnerText.GetComponent<TMPro.TextMeshProUGUI>().text = "SCISSORS CUTS PAPER!";
            youScore += 1;
            youScoreText.GetComponent<TMPro.TextMeshProUGUI>().text = youScore.ToString();
        }
    }

    //MATCH WINNER

    public void checkMatchWinner()
    {
        int comScore = Int32.Parse(comScoreText.GetComponent<TMPro.TextMeshProUGUI>().text);
        int youScore = Int32.Parse(youScoreText.GetComponent<TMPro.TextMeshProUGUI>().text);

        

        if (comScore > youScore && comScore == 3)
        {
            roundWinnerPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 1440);
            getPointsText.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 1440);
            winnerPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            playerChar.GetComponent<Animator>().enabled = false;
            comChar.GetComponent<Animator>().enabled = false;
            winnerText.GetComponent<TMPro.TextMeshProUGUI>().text = "COM WON!";
            
        }

        else if (youScore > comScore && youScore == 3)
        {
            roundWinnerPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 1440);
            getPointsText.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 1440);
            winnerPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            playerChar.GetComponent<Animator>().enabled = false;
            comChar.GetComponent<Animator>().enabled = false;
            winnerText.GetComponent<TMPro.TextMeshProUGUI>().text = "YOU WON!";
            
        }

        else
        {
            return;
        }

    }
}

