import { Word } from '@/scripts/word'
import { WordsService } from './wordsService'
import { Letter } from './letter'

export class WordleGame {
  constructor(secretWord?: string, numberOfGuesses: number = 6) {
    if (!secretWord) secretWord = WordsService.getRandomWord()
    this.numberOfGuesses = numberOfGuesses
    this.restartGame(secretWord)
  }
  guessedLetters: Letter[] = []
  guesses = new Array<Word>()
  secretWord = ''
  numberOfGuesses = 6
  guess!: Word

  restartGame(secretWord: string) {
    this.secretWord = secretWord || WordsService.getRandomWord()
    this.guesses.splice(0)
    // create a word for each guess
    for (let iWord = 0; iWord < this.numberOfGuesses; iWord++) {
      const word = new Word(secretWord.length)
      this.guesses.push(word)
    }
    this.guess = this.guesses[0]
  }

  submitGuess() {
    // put logic to win here.
    this.guess.check(this.secretWord)

    // Update the guessed letters
    for(const letter of this.guess.letters){
      this.guessedLetters.push(letter)
    }

    const index = this.guesses.indexOf(this.guess)
    if (index < this.guesses.length - 1) {
      this.guess = this.guesses[index + 1]
    } else {
      // The game is over
    }
  }
}