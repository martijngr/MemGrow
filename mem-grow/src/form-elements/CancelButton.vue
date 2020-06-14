<template>
  <font-awesome-icon
          icon="arrow-right"
          class="btn-icon cancel normal"
          @click="onClick()"
        />
</template>

<script>
export default {
    name: 'CancelButton',
    methods: {
        onClick(){
            this.$emit('onClick');
        }
    },
}
</script>

<style>

</style>