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

export default {
  name: "memGrowCategoryDropdown",
  data() {
    return {
      categories: [],
      selectedItem: "",
      createNewCategory: false,
      newCategoryName: ""
    };
  },
  created() {
    this.loadCategories();
  },
  methods: {
    loadCategories() {
      this.categories = [
        {
          name: "Nieuwe categorie aanmaken",
          id: 0
        },
        {
          name: "Cat 1",
          id: -1
        },
        {
          name: "Cat 2",
          id: -2
        },
        {
          name: "Cat 3",
          id: -3
        }
      ];
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