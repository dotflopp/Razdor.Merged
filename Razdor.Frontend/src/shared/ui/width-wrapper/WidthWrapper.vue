<template>
    <div class="width-wrapper" :style=wrapperStyle>
        <slot></slot>
    </div>
</template>

<script setup lang="ts">
    let props = defineProps<{
        maxWidth?: string
    }>()

    let wrapperStyle: string | undefined = undefined;  
    
    if (props.maxWidth != null){
        wrapperStyle = `max-width: ${props.maxWidth};`
    }
</script>

<style>
    .width-wrapper {
        max-width: 800px;
        margin: 0 auto;
    }
</style>