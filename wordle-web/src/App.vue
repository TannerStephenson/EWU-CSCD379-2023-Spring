<template>
  <header>
    <div class="wrapper">
      <HelloWorld msg="Welcome!" />

      <nav class>
        <v-divider></v-divider>
        <RouterLink to="/">Home</RouterLink>
        <RouterLink to="/game">Wordle</RouterLink>
        <RouterLink to="/github">Github repo</RouterLink>
        <RouterLink to="/about">About</RouterLink>
        <RouterLink to="/practice">Practice</RouterLink>
        <v-divider></v-divider>
      </nav>
    </div>
  </header>

  <RouterView />
</template>

<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import HelloWorld from './components/HelloWorld.vue'
</script>

<style>
header {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  padding: auto;
}

.logo {
  display: block;
  margin: 0 auto 2rem;
}


nav {
  width: 100%;
  font-size: 12px;
  text-align: center;
  margin-top: 2rem;
  
}

nav a.router-link-exact-active {
  color: var(--color-text);
}

nav a.router-link-exact-active:hover {
  background-color: transparent;
}

nav a {
  display: inline-block;
  padding: 0 1rem;
  border-left: 1px solid var(--color-border);
  color: rgb(138, 214, 138);
}

nav a:first-of-type {
  border: 0;
}

@media (min-width: 1024px) {
  header {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    padding: auto;
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  header .wrapper {
    display: center;
    place-items: flex-start;
    flex-wrap: wrap;
    width: 100%;
    margin: auto
  }

  nav {
    text-align: center;
    margin-left: -1rem;
    font-size: 1rem;

    padding: 1rem 0;
    margin-top: 1rem;
  }

}
</style>
