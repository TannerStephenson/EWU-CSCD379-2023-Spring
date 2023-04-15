<template>
  <div class="about">
    <v-card>
      <v-card-title> Check out this repo on github! </v-card-title>
        <v-card-actions>
          <RouterLink :to="{ path: '/' }">
            <v-btn text color="warning">
              Home
            </v-btn>
          </RouterLink>
          <v-btn text color="primary">
            <a href="https://github.com/TannerStephenson/EWU-CSCD379-2023-Spring">Github</a>
          </v-btn>
        </v-card-actions>
    </v-card>
  </div>
</template>

<style>
@media (min-width: 1024px) {
  .about {
    min-height: 100vh;
    display: flex;
    align-items: center;
  }
}
</style>