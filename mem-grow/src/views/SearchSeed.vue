<template>
  <div>
    <div>Je hebt gezocht naar '{{keyword}}':</div>
    <div>
      <div v-for="item in vm.searchResults" :key="item.id" class="search-result-item">
        {{item.description}}
        <br />
        <span class="category">{{item.categoryName}}</span>
      </div>
    </div>
  </div>
</template>

<script>
import { SeedService } from "../services/SeedService";

export default {
  data() {
    return {
      vm: {
        searchResults: []
      }
    };
  },
  props: {
    keyword: {
      type: String,
      default: ""
    }
  },
  async created() {
    await this.search(this.keyword);
  },
  watch: {
    keyword(newVal) {
      this.search(newVal);
    }
  },
  methods: {
    async search(keyword) {
      this.vm.searchResults = await SeedService.searchSeed(keyword);
    }
  }
};
</script>

<style scoped>
.search-result-item {
  background: #f4f4f4;
  border-radius: 5px;
  margin-top: 25px;
  padding: 10px;
}

.search-result-item .category {
  margin-top: 10px;
  border-radius: 5px;
  display: inline-block;
  padding: 5px;
  background: #fbfafa;
}
</style>