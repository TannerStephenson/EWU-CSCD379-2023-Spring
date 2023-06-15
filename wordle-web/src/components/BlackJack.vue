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
            <v-img v-if="!dealersFlipped && index === 0" :src="cardBackUrl"></v-img>
            <div v-else>
              <v-card-title class="black-font" style="text-align: left">
                <v-icon>{{ card.Suit }}</v-icon>
                {{ card.character }}
              </v-card-title>
                <v-spacer>
                  <v-card class="mx-auto" height="160px" width="150px" color="black" variant="outlined">
                    <v-card-title style="font-size: small;">Grant's Casino</v-card-title>
                    <v-img :src="GrantUrl"></v-img>
                  </v-card>
                </v-spacer>
                <v-card-title class="black-font" style="text-align: right">
                {{ card.character }}
                <v-icon>{{ card.Suit }}</v-icon>
              </v-card-title>
            </div>
          </transition>
        </v-card>
      </v-row>
    </div>

      <div class="d-flex justify-center pa-2 text-h6">
        <v-card height="50px" width="375px" class="align-center justify-center mt-5 text-center">
          <v-card-title>Dealer stands on 17+</v-card-title>
        </v-card>
      </div>
  
      <div class="d-flex justify-center pa-2 text-h6">
      <v-row class="align-center justify-center mt-5 text-center">
        <v-card v-for="(card, index) in playerCards" :key="index" height="250px" width="175px" style="margin-right: 20px; background-color: white;">
          <transition name="card-flip">
            <v-img v-if="!flipped" :src="cardBackUrl"></v-img>
            <div v-else>
              <v-card-title class="black-font" style="text-align: left">
                <v-icon>{{ card.Suit }}</v-icon>
                {{ card.character }}
              </v-card-title>
                <v-spacer>
                  <v-card class="mx-auto" height="160px" width="150px" color="black" variant="outlined">
                    <v-card-title style="font-size: small;">GRANT'S CASINO</v-card-title>
                    <v-img :src="GrantUrl"></v-img>
                  </v-card>
                </v-spacer>
                <v-card-title class="black-font" style="text-align: right">
                {{ card.character }}
                <v-icon>{{ card.Suit }}</v-icon>
              </v-card-title>
            </div>
          </transition>
        </v-card>
      </v-row>
    </div>

    <v-dialog v-model="dialog">
      <v-card class="mx-auto" width="350px" height="150px">
        <v-card-title v-if="win">Win!</v-card-title>
        <v-card-text v-if="win">Congratulations! You have won!</v-card-text>
        <v-card-title v-else>Bust!</v-card-title>
        <v-card-text v-else>You have lost!</v-card-text>
      </v-card>
    </v-dialog>

    <div class="d-flex justify-center pa-2 text-h6">
      <v-card height="225px" width="325px" class="align-center justify-center mt-5 text-center">
        <v-card-title>Player's Card</v-card-title>
        <v-card-title>Player's Hand Total: {{ playerHandTotal }}</v-card-title>
        <v-btn @click="stay">
          <v-icon>mdi-hand-back-left</v-icon>
          <v-card-text> Stay </v-card-text>
        </v-btn>
        <v-btn @click="hit">
          <v-icon>mdi-cards</v-icon>
          <v-card-text> Hit </v-card-text>
        </v-btn>
        <v-spacer></v-spacer>
        <v-text>Chips: {{ chip }}</v-text>
        <v-spacer></v-spacer>
        <v-text>Bet amount: {{ betAmount }}</v-text>
        <v-slider
          v-model="betAmount"
          :min="10"
          :max="100"
          :step="10"
          thumb-label
          style="width: 200px; margin: 0 auto;"
        ></v-slider>
        <v-btn @click="flipCards">
          <v-card-text> Flip Cards Test </v-card-text>
        </v-btn>
      </v-card>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, watch } from 'vue';
import Axios from 'axios';
import { defineProps } from 'vue';
import type { Card } from '@/scripts/card';
import { onMounted } from 'vue';
import type { Chip } from '@/scripts/chip';
import GrantsHead from '../assets/GrantsHead.png';
import axios from 'axios';

const flipped = ref(true);
const dealersFlipped = ref(false);
const cardBackUrl = ref('https://opengameart.org/sites/default/files/card%20back%20black.png');
const GrantUrl = ref(GrantsHead);
const playerCards = ref<Card[]>([]);
const dealerCards = ref<Card[]>([]);
const playerHandTotal = ref(0);
const dealerHandTotal = ref(0);
const dialog = ref(false);
const win = ref(false);
const betAmount = ref(10);
const chip = ref(0);



const props = defineProps<{
  card: Card
  chip: Chip
  //CardValue: number
  //Suit: string
}>()

onMounted(() => {
  getChips();
  updateChipCount();
  newGame();
})

async function newGame() {
  // Reset the game
  
  flipped.value = false;
  playerCards.value = [];
  dealerCards.value = [];
  await dealersHit();
  await dealersHit();
 
  // Deal the cards
  await hit();
  await hit();
  await new Promise(r => setTimeout(r, 200));
  flipped.value = true;
  win.value = false;
}

async function getChips() {
  const response = await Axios.get('/api/Chip');
  const data = response.data;
  chip.value = data.chipCount;
  console.log(chip.value)
}

async function updateChipCount() {
  try {
    await Axios.post('/api/Chip', {chipCount: chip.value});
    console.log('Chip count updated successfully', chip.value);
  } catch (error) {
    console.error('Failed to update chip count:', error);
  }
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
    playerCards.value = [...playerCards.value, newCard];
    await new Promise((resolve) => setTimeout(resolve, 500));
    return newCard;
  } catch (error) {
    console.log(error);
    throw error;
  }
}

async function dealersHit() {
  try {
    const response = await Axios.get('/api/Card');
    const newCard = response.data as Card;
    newCard.Suit = createCardLogo(newCard);
    dealerCards.value.push(newCard);
    await new Promise((resolve) => setTimeout(resolve, 370));
    return newCard;
  } catch (error) {
    console.log(error);
    throw error;
  }
}

async function stay() {
  // Handle the "Stay" button functionality
  dealersFlipped.value = true;
  await new Promise((resolve) => setTimeout(resolve, 1275));
  dealerHandTotal.value = calculateHandTotal(dealerCards.value);
  while (dealerHandTotal.value < 17) {
    await dealersHit();
    dealerHandTotal.value = calculateHandTotal(dealerCards.value);
    await new Promise((resolve) => setTimeout(resolve, 500));
  }
  if (dealerHandTotal.value > 21) {
    // Dealer has gone bust
    console.log("Dealer has gone bust!");
    win.value = true;
    dialog.value = true;
    // Wait a few seconds
    setTimeout(() => {
      dialog.value = false;
      winGame();
    }, 1750);
  } else {
    // Compare hands
    if (dealerHandTotal.value > playerHandTotal.value) {
      // Dealer wins
      console.log("Dealer wins!");
      dialog.value = true;
      // Wait a few seconds
      setTimeout(() => {
        dialog.value = false;
        lose();
      }, 1750);
    } else if (dealerHandTotal.value < playerHandTotal.value) {
      // Player wins
      console.log("Player wins!");
      dialog.value = true;
      win.value = true;
      // Wait a few seconds
      setTimeout(() => {
        dialog.value = false;
        winGame();
      }, 1750);
    } else {
      // Tie
      console.log("Tie!");
      // Wait a few seconds
      setTimeout(() => {
        dialog.value = false;
        tieGame();
      }, 1750);
    }
  }
  dealersFlipped.value = false;
}

function winGame() {
  const winnings = betAmount.value;
  increasePlayerChips(winnings)
    .then(() => {
      console.log("Player's chips increased by", winnings);
      betAmount.value = 10;  // Reset the bet amount to the default value
      newGame();
    })
    .catch((error) => {
      console.error("Error increasing player's chips:", error);
    });
}

function lose() {
  const losses = betAmount.value;
  decreasePlayerChips(losses)
    .then(() => {
      console.log("Player's chips decreased by", losses);
      betAmount.value = 10;  // Reset the bet amount to the default value
      newGame();
    })
    .catch((error) => {
      console.error("Error decreasing player's chips:", error);
    });
}

function tieGame() {
  betAmount.value = 10;  // Reset the bet amount to the default value
  newGame();
}

async function increasePlayerChips(amount: number) {
  try {
    const newChips = chip.value + amount;
    chip.value = newChips;
    await updateChipCount();
    console.log("Player's chips increased by", amount);
  } catch (error) {
    console.error("Failed to increase player's chips:", error);
  }
}

async function decreasePlayerChips(amount: number) {
  try {
    const newChips = chip.value - amount;
    chip.value = newChips;
    await updateChipCount();
    console.log("Player's chips decreased by", amount);
  } catch (error) {
    console.error("Failed to decrease player's chips:", error);
  }
}


watch(playerCards, (newCards) => {
  playerHandTotal.value = calculateHandTotal(newCards);
  if (playerHandTotal.value > 21) {
    // Player has gone bust
    console.log("Player has gone bust!");
    dialog.value = true;
    //Wait a few seconds
    setTimeout(() => {
      dialog.value = false;
      newGame();
    }, 1750);
    
  }
});

function calculateHandTotal(cards: Card[]): number {
  let total = 0;
  let hasAce = false;
  for (const card of cards) {
    if (card.cardValue === 11) {
      total += 11; // Assume 11 for now, we'll adjust later if needed
      hasAce = true;
    }
     else {
      total += card.cardValue;
    }
  }
  if (hasAce && total > 21) {
    // Adjust ace value from 11 to 1
    total -= 10;
  }
  return total;
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

.red-font {
  color: red;
}

.card-flip-enter,
.card-flip-leave-to {
  transform: rotateY(180deg);
}
</style>