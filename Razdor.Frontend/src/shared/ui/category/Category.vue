<script setup lang="ts">
import { classicNameResolver } from 'typescript';
import { isVNode } from 'vue';
import { Title } from "../"

    const props = defineProps<{
        title: string,
    }>()
</script>

<template>
    <article class="category">
        <Title>
            {{title}}
        </Title>    
        <slot></slot>
    </article>
</template>


<style>
@import url(./styles.css);
</style>