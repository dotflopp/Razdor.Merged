<script lang="ts" setup>
    let className = "modal-window";
</script>

<template>
    <div :class="className">        
        <slot></slot>
    </div>
</template>

<style scoped>
@import url("./styles.css");
</style>