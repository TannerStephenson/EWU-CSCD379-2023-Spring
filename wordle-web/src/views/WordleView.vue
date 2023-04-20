<template>
  <div class="game">
    <div>
      <v-row class="justify-center" v-for="word in game.guesses" :key="word.text">
        <v-col cols="auto" v-for="letter in word.letters" :key="letter.char">
          <LetterButton :letter="letter"></LetterButton>
        </v-col>
      </v-row>
    </div>>
    <v-card>
      <v-select label="Possible words" :items="WordsService.validWords(guess)"> </v-select>
    </v-card>

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

function wasClicked() {
  console.log('clicked')
}

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
