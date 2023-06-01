<template>
    <div>
      <div class="d-flex justify-center pa-2 bg-green text-h6">
        <v-card height="50px" width="175px" class="align-center justify-center mt-5 text-center">
          <v-card-title>Dealer's Card</v-card-title>
        </v-card>
      </div>
      <div class="d-flex justify-center pa-2 text-h6">
        <v-row class="align-center justify-center mt-5 text-center">
          <v-card height="250px" width="175px" style="margin-right: 20px">
            <transition name="card-flip">
              <v-img v-if="!flipped" :src="cardBackUrl"></v-img>
            </transition>
          </v-card>
          <v-card height="250px" width="175px">
            <transition name="card-flip">
              <v-img v-if="!flipped" :src="cardBackUrl"></v-img>
            </transition>
          </v-card>
        </v-row>
      </div>
  
      <div class="d-flex justify-center pa-2 text-h6">
      <v-row class="align-center justify-center mt-5 text-center">
        <v-card v-for="(card, index) in playerCards" :key="index" height="250px" width="175px" style="margin-right: 20px">
          <transition name="card-flip">
            <v-img v-if="!flipped" :src="cardBackUrl"></v-img>
          </transition>
        </v-card>
        <v-card height="250px" width="175px" style="margin-right: 20px">
          <transition name="card-flip">
            <v-img v-if="!flipped" :src="cardBackUrl"></v-img>
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

const flipped = ref(false);
const cardBackUrl = ref('https://opengameart.org/sites/default/files/card%20back%20black.png');
const playerCards = ref([]);

function flipCards() {
  flipped.value = !flipped.value;
}

function hit() {
  // Add a new card to the player's hand
  playerCards.value.push({});
}

function stay() {
  // Handle the "Stay" button functionality
  // ... (your logic here)
}
</script>

<style scoped>
.card-flip-enter-active,
.card-flip-leave-active {
  transition: transform 0.5s;
}

.v-card {
  margin-left: 3px;
}

.card-flip-enter,
.card-flip-leave-to {
  transform: rotateY(180deg);
}
</style>