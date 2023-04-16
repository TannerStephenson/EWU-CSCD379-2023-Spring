<template>
  <div class="greetings">
    <h1 class="green">{{ msg }}</h1>
    <h3>
      This is a project created by
      <br> Tanner Stephenson
    </h3>
  </div>
</template>

<script setup lang="ts">
defineProps<{
  msg: string
}>()
</script>

<style scoped>
h1 {
  font-weight: 500;
  font-size: 2.6rem;
  top: 10px;
  padding: auto;
}

h3 {
  font-size: 1.2rem;
}

.greetings h1 {
  text-align: center;
  margin: center;
}
.greetings h3 {
  text-align: center;
  margin: center;
  padding: auto;
}


@media (min-width: 1024px) {
  .greetings h1{
    padding: auto;
  }
  .greetings h3 {
    text-align: center;
    margin: center;
    padding: auto;
  }
}
</style>
