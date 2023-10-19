using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HangmanManager : MonoBehaviour
{
    //GAME
    // Have a collection of words that can be used
    [SerializeField] private string[] wordList;
    [SerializeField] private string chosenWord;
    [SerializeField] private char[] lettersOfChosenWord;
    [SerializeField] private Text[] displayLetters;

    private void Start()
    {
        ChooseWord();
    }

    void ChooseWord()
    {
        // Choose a word at random and store it in a variable
        int randomNumber = Random.Range(0, wordList.Length);
        chosenWord = wordList[randomNumber];
        lettersOfChosenWord = chosenWord.ToCharArray();
        // Display the length of the word to the user
        for (int i = 0; i < displayLetters.Length; i++)
        {
            if (i < lettersOfChosenWord.Length)
            {
                displayLetters[i].gameObject.SetActive(true);
            }
            else
            {
                displayLetters[i].gameObject.SetActive(false);
            }
        }
    }

    //Prompt the user to guess a letter
    public void GuessLetter(Text letter)
    {
        //If the guess is correct
        if (chosenWord.Contains(letter.text))
        {
            //Display guessed letter to user
            for (int i = 0;i < lettersOfChosenWord.Length; i++)
            {
                if (lettersOfChosenWord[i].ToString() == letter.text)
                {
                    letter.gameObject.GetComponentInParent<Image>().color = Color.green;
                    displayLetters[i].text = letter.text;
                }
            }

        }
        //If the guess is incorrect
        else
        {
            //Display incorrect letter to user 
            letter.gameObject.GetComponentInParent<Image>().color = Color.red;

        }
        //block ability to use letter in next guess
        letter.gameObject.GetComponentInParent<Button>().interactable = false;
    }



    //Display Visual to user of how many chances left to guess
    //If the incorrect guesses have all been marked off tell the user 
    //They lost 
    // Allow user to exit the program or return to menu
    //If correct guess of the word
    //Tell the user they won
    //Prompt to play again
    //Allow user to leave game
}
