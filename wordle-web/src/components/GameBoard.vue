<template>
        <v-row class="justify-center" dense v-for="(word, r) in game.guesses" :key="r">
          <v-col cols="auto" v-for="(letter, c) in word.letters" :key="`${r}-${c}`">
            <LetterButton :letter="letter"></LetterButton>
          </v-col>
        </v-row>
</template>

<script lang = "ts">
import { WordleGame } from '@/scripts/wordleGame.vue';
import { defineProps } from 'vue';
import LetterButton from '@/components/LetterButton.vue'
import { reactive } from 'vue'


defineProps<{
    game: wordleGame 
}>()
</script>
