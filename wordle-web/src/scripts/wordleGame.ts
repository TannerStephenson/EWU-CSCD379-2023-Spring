import { Letter, LetterStatus } from '@/scripts/letter'
import { ref, reactive } from 'vue'
import { Word } from './word'
import { WordsService } from './wordsService'

export class WordleGame {
  constructor(secretWord?: string) {
    this.resetGame(secretWord)
  }
  guesses = new Array<Word>()
  secretWord = ''

  resetGame(secretWord?: string) {
    this.secretWord = secretWord ?? WordsService.getRandomWord()
    this.guesses.splice(0)
  }

  submitGuess(guess: string) {
    const word = new Word(guess)
    this.guesses.push(word)
    word.check(this.secretWord)
  }
}