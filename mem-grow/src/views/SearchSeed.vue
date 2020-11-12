<template>
  <div>
    <div>Je hebt gezocht naar '{{keyword}}':</div>
    <div v-if="vm.searchResults.length > 0">
      <div v-for="item in vm.searchResults" :key="item.seedId" class="search-result-item">
        <div>{{item.description}}</div>
        <div class="search-bottom-bar">
          <div>
            <span class="category">{{item.categoryName}}</span>
          </div>
          <div>
            <router-link
              tag="a"
              class
              :to="{ name: 'EditMemGrow', params: { id: item.seedId } }"
            >
              <font-awesome-icon
                icon="pencil-alt"
                @click="onEditClick()"
                class="btn-icon default smaller"
              />
            </router-link>
            <font-awesome-icon
              icon="trash"
              @click="onDeleteClick(item)"
              class="btn-icon default smaller"
            />
          </div>
        </div>
      </div>
    </div>
    <div v-if="vm.searchResults.length == 0" class="no-search-results">
      Geen resultaten gevonden.
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
    },
    async onDeleteClick(seed) {
      var result = confirm("Weet je zeker dat je dit zaadje wilt verwijderen?");

      if (result) {
        await SeedService.deleteSeed(seed.seedId);

        this.vm.searchResults = this.vm.searchResults.filter(s => s.seedId != seed.seedId);
      }
    },
  }
};
</script>

<style scoped>
.no-search-results{
  margin-top: 20px;
}
.search-result-item {
  background: #f4f4f4;
  border-radius: 5px;
  margin-top: 25px;
  padding: 10px;
  white-space: pre-line;
}

.search-result-item .category {
  border-radius: 5px;
  display: inline-block;
  padding: 5px;
  background: #fbfafa;
}

.search-bottom-bar{
  margin-top: 20px;
  display: flex;
  justify-content:space-between;
}

.search-bottom-bar .btn-icon
{
  margin-left: 15px;
}
</style>