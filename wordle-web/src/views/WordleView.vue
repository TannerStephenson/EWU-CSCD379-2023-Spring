<template>
  <div class="game">
    <h1>Wordle Mind Bender</h1>
    <v-text-field v-model="guess" label="Guess" variant="solo"></v-text-field>

    <v-btn @click="checkGuess">Check</v-btn>
    <v-card>
      <v-select label="Possible words" :items="WordsService.validWords(guess)"> </v-select>
    </v-card>
    <div>
      <v-row v-for="word in game.guesses" :key="word.text">
        <v-col v-for="letter in word.letters" :key="letter.char">
          <LetterButton :letter="letter"></LetterButton>
        </v-col>
      </v-row>
    </div>

    <h2>{{ guess }}</h2>
    <h3>{{ game.secretWord }}</h3>
  </div>
</template>

<script setup lang="ts">
import LetterButton from '@/components/LetterButton.vue'
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive } from 'vue'
import { WordsService } from '@/scripts/wordsService'
import { watch, onMounted, onUnmounted } from 'vue'

const guess = ref('')
const game = reactive(new WordleGame())

console.log(game.secretWord)

onMounted(() => {
  window.addEventListener('keyup', keyPress)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

function keyPress(e: KeyboardEvent) {
  if (e.key.length === 1) {
    game.currentGuess.push(e.key)
  }
  // Submit on enter
  if (e.key === 'Enter') {
    checkGuess()
  }
  // Backspace
  if (e.key === 'Backspace') {
    game.currentGuess.pop()
  }
}

watch(
  guess,
  (newGuess, oldGuess) => {
    if (newGuess.length > 5) {
      guess.value = oldGuess || ''
    }
  },
  { flush: 'post' }
)

function checkGuess() {
  game.submitGuess()
}
</script>

<style scoped>
v-btn {
  margin: 0.5rem;
}
</style>
