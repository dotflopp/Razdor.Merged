<script lang="ts" setup>
    import type { Component } from 'vue';
    import BaseParameter from '../base-parameter/BaseParameter.vue';
    import ArrowRightIcon from '@/shared/svg/ArrowRightIcon.vue';
    defineProps<{
        icon: Component,
        name: string
    }>()
</script>

<template>
    <BaseParameter :use-label="true" :icon="icon" :name="name">
        <ArrowRightIcon class="parameter__refrenece__icon" fill-color="#6c717c"/>
    </BaseParameter>
</template>

<style>
/* @import url("./styles.css"); */
</style>