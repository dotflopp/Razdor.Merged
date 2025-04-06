<script lang="ts" setup>
    import type { Component } from 'vue';
    import { BaseParameter } from '..';
    
    defineProps<{
        icon: Component,
        name: string
    }>()
</script>

<template>
    <BaseParameter :icon="icon" :name="name">
    </BaseParameter>
</template>