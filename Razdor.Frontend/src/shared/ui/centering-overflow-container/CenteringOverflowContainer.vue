<script lang="ts" setup>
    import { ref, onBeforeUnmount, onMounted } from 'vue';

    const resizeObserver = new ResizeObserver((entries) =>{
        entries.forEach(entry => {
            const contentWidth = entry.target.scrollWidth
            const currentWidth = entry.target.clientWidth

            if (currentWidth >= contentWidth)
                return

            entry.target.scrollLeft = (contentWidth - currentWidth) / 2
        })
    })

    const root = ref<HTMLElement | null>(null);

    onMounted(()=>{
        if (root.value != null)
            resizeObserver.observe(root.value)
    })

    onBeforeUnmount(()=>{
        resizeObserver.disconnect()
    })

</script>

<template>
    <div ref="root" class="centering-overflow-container">
        <slot></slot>
    </div>
</template>