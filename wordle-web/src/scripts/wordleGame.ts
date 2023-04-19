import { Letter, LetterStatus } from '@/scripts/letter'
import { ref, reactive } from 'vue'
import { Word } from './word'
import { WordsService } from './wordsService'

export enum WordleGameState {
  Active = 0,
  Won = 1,
  Lost = 2
}

export class WordleGame {
  constructor(secretWord?: string) {
    this.resetGame(secretWord)
  }

  

  currentGuessIndex = 0
  guesses = new Array<Word>()
  secretWord = ''
  status = WordleGameState.Active

  resetGame(secretWord?: string | null, numberOfGuesses: number = 6) {
    this.secretWord = secretWord || WordsService.getRandomWord()
    this.guesses.splice(0)


    for (let i = 0; i < numberOfGuesses; i++) {
      const word = new Word()
      this.guesses.push(word)
    }
    this.currentGuessIndex = 0
  }

  get currentGuess() {
    return this.guesses[this.currentGuessIndex]
  }

  submitGuess() {
    if (this.currentGuess.check(this.secretWord)) {
      this.status = WordleGameState.Won
    }
     else if (this.currentGuessIndex === this.guesses.length - 1) {
      this.status = WordleGameState.Lost
    }
    this.currentGuessIndex++
  }
}
