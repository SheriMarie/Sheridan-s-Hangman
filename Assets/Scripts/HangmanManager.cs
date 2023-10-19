using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HangmanManager : MonoBehaviour
{
    //GAME
    // Have a collection of words that can be used
    [SerializeField] private string[] _wordList;
    [SerializeField] private string _chosenWord;
    [SerializeField] private char[] _lettersOfChosenWord;
    [SerializeField] private Text[] _displayLetters;
    [SerializeField] private Duckie[] _displayDucks;
    [SerializeField] private int _guesses;
    private bool gameWon = false;
    private bool gameLost = false;
    [Serializable]
    public struct Duckie
    {
        public SpriteRenderer duckAlive;
        public SpriteRenderer duckDed;
        public SpriteRenderer duckDrown;
    }

    private void Start()
    {
        ChooseWord();
    }

    void ChooseWord()
    {
        // Choose a word at random and store it in a variable
        int randomNumber = UnityEngine.Random.Range(0, _wordList.Length);
        _chosenWord = _wordList[randomNumber];
        _lettersOfChosenWord = _chosenWord.ToCharArray();
        // Display the length of the word to the user
        for (int i = 0; i < _displayLetters.Length; i++)
        {
            if (i < _lettersOfChosenWord.Length)
            {
                _displayLetters[i].gameObject.SetActive(true);
            }
            else
            {
                _displayLetters[i].gameObject.SetActive(false);
            }
        }
    }

    //Display Visual to user of how many chances left to guess

    //Prompt the user to guess a letter
    public void GuessLetter(Text letter)
    {
        //If the guess is correct
        if (_chosenWord.Contains(letter.text))
        {
            //Display guessed letter to user
            for (int i = 0;i < _lettersOfChosenWord.Length; i++)
            {
                if (_lettersOfChosenWord[i].ToString() == letter.text)
                {
                    letter.gameObject.GetComponentInParent<Image>().color = Color.green;
                    _displayLetters[i].text = letter.text;
                }
            }

            //If correct guess of the word
            //Tell the user they won
            //Prompt to play again
            //Allow user to leave game

        }
        //If the guess is incorrect
        else
        {
            //Display incorrect letter to user 
            letter.gameObject.GetComponentInParent<Image>().color = Color.red;

            if (_guesses > 0)
            {
                if (_guesses < 5)
                {
                  //  _displayDucks[_guesses.]
                }
                //Increment incorrect guesses by 1
                _guesses--;
                _displayDucks[_guesses].duckAlive.color = new Color(1,1,1,0);
                _displayDucks[_guesses].duckDed.color = Color.white;
                Invoke("DrownDuck", 0.75f);
            }

            //If the incorrect guesses have all been marked off tell the user 
            if (_guesses == 0)
            {
                letter.gameObject.GetComponentInParent<Button>().interactable = false; 
                //They lost 
                // Allow user to exit the program or return to menu
            }

        }
        //block ability to use letter in next guess
        letter.gameObject.GetComponentInParent<Button>().interactable = false;



    }


    void DrownDuck()
    {
        _displayDucks[_guesses].duckDed.color = new Color(1, 1, 1, 0);
        _displayDucks[_guesses].duckDrown.color = Color.grey;
         StartCoroutine(DrownDuckieDrown());
    }


    IEnumerator DrownDuckieDrown()
    {

       while (_displayDucks[_guesses].duckDrown.transform.localPosition.y > -2.6)
       {
            _displayDucks[_guesses].duckDrown.transform.position += Vector3.down * 1f * Time.deltaTime;
            // yield return new WaitForSeconds(.1f);
            yield return null;
        }
    }
}
