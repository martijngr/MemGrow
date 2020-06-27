<template>
  <form @submit.prevent="onSave">
    <div class="form-group">
      <label for="seed">Welk zaadje moet gepland worden?</label>
      <textarea
      v-on:keydown.enter="$event.stopPropagation()"
        class="form-control"
        id="seed"
        placeholder="Wat wil je onthouden?"
        v-model="vm.seed"
      ></textarea>
    </div>
    <div class="form-group">
      <label for="category">Category</label>
      <MemGrowCategoryDropdown @changed="onCategoryChanged" />
    </div>
    <button type="submit" class="btn btn-primary" :disabled="!canSaveForm()">Opslaan</button>
    <div>
      <pre>
        {{vm.seed}} in category {{vm.selectedCategory}}
        </pre>
    </div>
    <pre>
      {{$v}}
      </pre>
  </form>
</template>

<script>
import MemGrowCategoryDropdown from "./MemGrowCategoryDropdown.vue";
import { required, minValue } from "vuelidate/lib/validators";
import {SeedService} from '../services/SeedService';

export default {
  name: "AddMemGrowForm",
  data() {
    return {
      vm: {
        seed: "",
        selectedCategory: ""
      }
    };
  },
  components: { MemGrowCategoryDropdown },
  methods: {
    onCategoryChanged(categoryId) {
      this.vm.selectedCategory = categoryId;
    },
    async onSave() {
      if (this.$v.$invalid) {
        alert('invalid form!');
      } else {
        await SeedService.saveSeed(this.vm);

        alert("Saved!");
      }
    },
    canSaveForm() {
      return !this.$v.vm.$invalid;
    }
  },
  validations: {
    vm: {
      selectedCategory: {
        required,
        minValue: minValue(1)
      },
      seed: {
        required
      }
    }
  }
};
</script>

<style>
</style>