<template>
  <form @submit.prevent="onSave">
    <div class="form-group">
      <label for="seed">Welk zaadje moet gepland worden?</label>
      <textarea
        v-on:keydown.enter="$event.stopPropagation()"
        class="form-control"
        id="seed"
        placeholder="Wat wil je onthouden?"
        v-model="seed.description"
      ></textarea>
    </div>
    <div class="form-group">
      <label for="category">Category</label>
      <MemGrowCategoryDropdown @changed="onCategoryChanged" :selected="seed.categoryId" />
    </div>
    <button type="submit" class="btn btn-primary" :disabled="!canSaveForm()">Opslaan</button>
  </form>
</template>

<script>
import { SeedService } from "../services/SeedService";
import MemGrowCategoryDropdown from "../components/MemGrowCategoryDropdown.vue";

export default {
  data() {
    return {
      seed: {}
    };
  },
  props: {
    id: {
      type: Number,
      default: 0
    }
  },
  methods: {
      onCategoryChanged(newCat){
          console.log(newCat);
      },
      canSaveForm(){
          return true;
      },
      async onSave(){
        await SeedService.editSeed(this.seed);
        
        this.$router.push({ name: 'Home' });
      }
  },
  components: { MemGrowCategoryDropdown },
  async created() {
    this.seed = await SeedService.getSeedById(this.id);
  }
};
</script>

<style>
</style>