<template>
    <div>
      <div class="d-flex justify-center pa-2 bg-green text-h6">
        <v-card height="50px" width="175px" class="align-center justify-center mt-5 text-center">
          <v-card-title>Dealer's Card</v-card-title>
        </v-card>
      </div>
      <div class="d-flex justify-center pa-2 text-h6">
        <v-row class="align-center justify-center mt-5 text-center">
        <v-card v-for="(card, index) in dealerCards" :key="index" height="250px" width="175px" style="margin-right: 20px; background-color: white;">
          <transition name="card-flip">
            <v-img v-if="!flipped" :src="cardBackUrl"></v-img>
            <v-card-title class="black-font" v-else>
              {{ card.cardValue }}
              <v-icon>{{ card.Suit }}</v-icon>
            </v-card-title>
          </transition>
        </v-card>
      </v-row>
      </div>
  
      <div class="d-flex justify-center pa-2 text-h6">
      <v-row class="align-center justify-center mt-5 text-center">
        <v-card v-for="(card, index) in playerCards" :key="index" height="250px" width="175px" style="margin-right: 20px; background-color: white;">
          <transition name="card-flip">
            <v-img v-if="!flipped" :src="cardBackUrl"></v-img>
            <v-card-title class="black-font" v-else>
              {{ card.cardValue }}
              <v-icon>{{ card.Suit }}</v-icon>
            </v-card-title>
            
          </transition>
        </v-card>
      </v-row>
    </div>

    <div class="d-flex justify-center pa-2 text-h6">
      <v-card height="175px" width="300px" class="align-center justify-center mt-5 text-center">
        <v-card-title>Player's Card</v-card-title>
        <v-btn @click="stay">
          <v-icon>mdi-hand-back-left</v-icon>
          <v-card-text> Stay </v-card-text>
        </v-btn>
        <v-btn @click="hit">
          <v-icon>mdi-cards</v-icon>
          <v-card-text> Hit </v-card-text>
        </v-btn>
        <v-btn @click="flipCards">
          <v-card-text> Flip Cards Test </v-card-text>
        </v-btn>
      </v-card>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import Axios from 'axios';
import { defineProps } from 'vue';
import type { Card } from '@/scripts/card';
import { onMounted } from 'vue';

const flipped = ref(true);
const dealersFlipped = ref(false);
const cardBackUrl = ref('https://opengameart.org/sites/default/files/card%20back%20black.png');
const playerCards = ref<Card[]>([]);
const dealerCards = ref<Card[]>([]);


const props = defineProps<{
  card: Card
  //CardValue: number
  //Suit: string
}>()

onMounted(() => {
  newGame();
})

async function newGame() {
  // Reset the game
  flipped.value = false;
  playerCards.value = [];
  dealerCards.value = [];
  const dealerFirst = await hit();
  const dealerSecond = await hit();

  dealerCards.value.push(dealerFirst);
  dealerCards.value.push(dealerSecond);
 
  // Deal the cards
  const firstCard = await hit();
  const secondCard = await hit();
  
  playerCards.value.push(firstCard);
  playerCards.value.push(secondCard);
}



function flipCards() {
  flipped.value = !flipped.value;
}

async function hit() {
  try {
    const response = await Axios.get('/api/Card');
    const newCard = response.data as Card;
    newCard.Suit = createCardLogo(newCard);
    console.log(playerCards.value);
    return newCard;
  } catch (error) {
    console.log(error);
    throw error; // or handle the error appropriately
  }
}

function stay() {
  // Handle the "Stay" button functionality
}

function createCardLogo(card: Card) {
  // Create the card art for the card
  let logo = '';
  switch (card.suit) {
    case 'SPADE':
      logo = 'mdi-cards-spade';
      break;
    case 'HEART':
      logo = 'mdi-heart';
      break;
    case 'DIAMOND':
      logo = 'mdi-cards-diamond';
      break;
    case 'CLUB':
      logo = 'mdi-cards-club';
      break;
    default:
      logo = 'mdi-cards';
      break;
  }
  return logo;
}

</script>

<style scoped>
.card-flip-enter-active,
.card-flip-leave-active {
  transition: transform 0.5s;
}

.black-font {
  color: black;
}

.card-flip-enter,
.card-flip-leave-to {
  transform: rotateY(180deg);
}
</style>