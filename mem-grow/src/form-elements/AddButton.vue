<template>
  <font-awesome-icon
          icon="plus-circle"
          @click="onSaveClick()"
          class="btn-icon success normal"
        />
</template>

<script>
export default {
    name: 'AddButton',
    methods: {
        onSaveClick(){
            this.$emit('onClick');
        }
    },
}
</script>

<style>

</style>