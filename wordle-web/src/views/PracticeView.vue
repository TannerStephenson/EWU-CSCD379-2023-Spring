<template>
  <div class="practice">
  <v-sheet color="blue" height="170px" class="pt-10 my-5">
    <v-card color="indigo-lighten-3" class="ma-5" elevation="5" rounded="xl">
      <v-card-title>Hello World</v-card-title>
    </v-card>
  </v-sheet>


  <v-row no-gutters>
    <v-col v-for="i in 25" :key="i" cols="5" sm="2" md="2" lg="2">
      <v-card class="ma-1">
        <v-card-title> {{ i }} </v-card-title>
      </v-card>
    </v-col>
  </v-row>
  </div>

</template>

<style scoped>
.practice {
    font-size: 1.2rem;
    text-align: center;
    margin: auto;
    top: 50%;
    left: 50%;
    position: fixed;
    
  }
v-col {
  padding: 0.5rem;
  color: #000;
}
</style>