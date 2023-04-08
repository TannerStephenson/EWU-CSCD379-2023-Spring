<template>
  <div class="game">
    <v-card>
      <v-card-title> Tic-Tac-Code </v-card-title>
      <v-card-subtitle></v-card-subtitle>

      <v-card-text>
        Lorem ipsum dolor sit amet blah blah blah
        <v-icon icon="mdi:mdi-abacus" />
      </v-card-text>

      <v-card-actions>
        <RouterLink :to="{ path: '/' }">
          <v-btn text color="warning">
            Home
          </v-btn>
        </RouterLink>
      </v-card-actions>
    </v-card>
  </div>
</template>

<script setup lang="ts">
</script>

<style>
.v-btn {
  border: black solid 1px;
  align-items: center;
  cursor: pointer;
}


@media (min-width: 1024px) {
  .about {
    min-height: 100vh;
    display: flex;
    align-items: center;
    justify-content: center;
  }
}
</style>