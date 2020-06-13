<template>
  <span>
    <select
      v-model="selectedItem"
      class="form-control"
      @change="valueChanged()"
      v-show="!createNewCategory"
    >
      <option
        v-for="category in categories"
        :value="category.id"
        :key="category.id"
      >{{ category.name }}</option>
    </select>

    <div v-show="createNewCategory">
      <input type="text" v-model="newCategoryName" ref="newCategoryInput" class="form-control" />
      <button type="button" @click="saveNewCategory()" class="btn btn-primary">+</button>
      <button type="button" class="btn btn-warning" @click="cancelNewCategory()">X</button>
    </div>
  </span>
</template>

<script>
import {SeedCategoryService} from '../services/SeedCategoryService';

export default {
  name: "memGrowCategoryDropdown",
  data() {
    return {
      categories: [{
        id:0,
        name:'Nieuwe categorie'
      }],
      selectedItem: "",
      createNewCategory: false,
      newCategoryName: ""
    };
  },
   async created() {
    await this.loadCategories();
  },
  methods: {
     async loadCategories() {
      const apiCategories = await SeedCategoryService.getSeedCategories();
      this.categories = this.categories.concat(apiCategories);
    },
    valueChanged() {
      if (this.selectedItem === 0) {
        this.createNewCategory = true;
        this.$nextTick(function() {
          this.$refs.newCategoryInput.focus();
        });
      } else {
        this.$emit("changed", this.selectedItem);
      }
    },
    cancelNewCategory() {
      this.selectedItem = "";
      this.createNewCategory = false;
    },
    saveNewCategory() {
      let cats = [...this.categories];
      var newCat = {
        id: parseInt(Math.random() * 10),
        name: this.newCategoryName
      };
      cats.push(newCat);

      this.categories = cats;
      this.selectedItem = newCat.id;
      this.createNewCategory = false;
      this.newCategoryName = "";
      this.valueChanged();
    }
  }
};
</script>

<style>
</style>