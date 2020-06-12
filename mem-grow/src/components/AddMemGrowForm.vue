<template>
  <form>
    <div class="form-group">
      <label for="exampleInputEmail1">Welk zaadje moet gepland worden?</label>
      <input
        type="text"
        class="form-control"
        id="memgrow"
        placeholder="Wat wil je onthouden?"
        v-model="memgrow"
      />
    </div>
    <div class="form-group">
      <label for="category">Category</label>
      <MemGrowCategoryDropdown @changed="onCategoryChanged" />
    </div>
    <button type="submit" class="btn btn-primary">Opslaan</button>
    <div>
      <pre>
        {{memgrow}} in category {{selectedCategory}}
        </pre>
    </div>
  </form>
</template>

<script>
import MemGrowCategoryDropdown from "./MemGrowCategoryDropdown.vue";

export default {
  name: "AddMemGrowForm",
  data() {
    return {
      memgrow: "",
      selectedCategory: ""
    };
  },
  components: {MemGrowCategoryDropdown},
  methods: {
      onCategoryChanged(categoryId){
          this.selectedCategory = categoryId;
      },
  },
};
</script>

<style>
</style>