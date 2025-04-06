<script lang="ts" setup>
import type { Component } from 'vue';

    defineProps<{
        icon: Component,
        name: string
        useLabel?: boolean
    }>()

</script>

<template>
    <div class="parameter"> 
        <component class="parameter__icon" :is="icon" v-bind="{fillColor: '#4F66E8'}"></component>
        <label v-if="useLabel" :for="name" class="parameter__name">{{ name }}</label>
        <span v-if="!useLabel" class="parameter__name">{{ name }}</span>
        <div :id="name" class="parameter__action">
            <slot></slot>
        </div>
    </div>
</template>

<style>
@import url("./styles.css");
</style>