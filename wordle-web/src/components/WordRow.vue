<template>
    <div class ="grid max-w-xs grid-cols-5 gap-1 mx-auto mb-1">
        <letter-box v-for="i in 5" :key="i" :letter="value[i - 1]"/>

    </div>
</template>

<script setup lang="ts">
import LetterBox from "./LetterBox.vue";
const props = defineProps({
    value: {
        type: String,
        default: '',
    },
    solution: String,
    submitted: Boolean,

});
</script>

