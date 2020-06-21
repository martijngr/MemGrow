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

    <div
      v-show="createNewCategory"
      style="display: flex; justify-content:space-between; align-items:center"
    >
      <input
        type="text"
        v-model="newCategoryName"
        ref="newCategoryInput"
        :class="{'form-control':true, 'error':$v.newCategoryName.$invalid}"
        style="width:75%;"
      />
      <div>
        <AddButton @onClick="saveNewCategory" :disabled="!canSaveNewCategory" />
      </div>
      <div>
        <CancelButton @onClick="cancelNewCategory" />
      </div>
    </div>
  </span>
</template>

<script>
import { SeedCategoryService } from "../services/SeedCategoryService";
import AddButton from "../form-elements/AddButton";
import CancelButton from "../form-elements/CancelButton";
import { required, minLength } from "vuelidate/lib/validators";

export default {
  name: "memGrowCategoryDropdown",
  data() {
    return {
      categories: [
        {
          id: 0,
          name: "Nieuwe categorie"
        }
      ],
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

      if (this.canAddNew){
        this.categories = this.categories.concat(apiCategories);
      }
      else{
         this.categories = apiCategories;
         this.selectedItem = this.categories[0].id;
      }
    },
    valueChanged() {
      if (this.selectedItem === 0) {
        this.createNewCategory = true;
        this.$nextTick(function() {
          this.$refs.newCategoryInput.focus();
        });
      }

      this.$emit("changed", this.selectedItem);
    },
    cancelNewCategory() {
      this.selectedItem = "";
      this.createNewCategory = false;

      this.valueChanged();
    },
    async saveNewCategory() {
      if (!this.canSaveNewCategory()) {
        alert("Invalid category name");
      } else {
        var saveResult = await SeedCategoryService.addSeedCategory(
          this.newCategoryName
        );

        let cats = [...this.categories];
        var newCat = {
          id: saveResult,
          name: this.newCategoryName
        };
        cats.push(newCat);

        this.categories = cats;
        this.selectedItem = newCat.id;
        this.createNewCategory = false;
        this.newCategoryName = "";
        this.valueChanged();
      }
    },
    canSaveNewCategory() {
      if (this.createNewCategory && !this.$v.newCategoryName.$invalid) {
        return true;
      } else {
        return false;
      }
    }
  },
  components: { AddButton, CancelButton },
  validations: {
    newCategoryName: {
      required,
      minLength: minLength(2)
    }
  },
  props: {
    canAddNew: {
      type: Boolean,
      default: true
    }
  }
};
</script>

<style scoped>
.error {
  border-color: red;
  background: #fdd;
}
</style>