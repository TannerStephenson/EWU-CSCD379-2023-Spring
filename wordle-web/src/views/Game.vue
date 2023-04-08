<template>
    <div id="input-container">
        <div class ="input-wrapper">
            <input type="text" id="input" v-model="text"/>
            <button class="submit-button" @click="submitText">Submit</button>
        </div>
    </div>
</template>

<script setup lang="ts">
    import { ref } from 'vue'
    import WordleGame from '../components/WordleGame.vue'

    const text = ref('')
    const submitText = () => {
        console.log(text.value)
    }
</script>

<style>
#input-container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  border: none;
}
#input {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 27px;
    width: 100px;
    border: 2px solid rgb(0, 0, 0);
    padding-bottom: 2px;
    background-color: white;
}
.submit-button {
    width: 100px;
    height: 40px;
    font-size: 1.5rem;
    background-color: #3896e4;
    color: #FFFFFF;
    border: 2px solid black;
    border-radius: 5px;
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