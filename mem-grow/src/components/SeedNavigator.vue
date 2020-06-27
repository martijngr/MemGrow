<template>
  <div>
    <div class="row">
      <div class="col-md-6">
        <MemGrowCategoryDropdown :canAddNew="false" :selected="currentSeed.categoryId" />
      </div>
    </div>
    <div class="row description-area">
      <div class="col-md-6">
        <pre>{{currentSeed.description}}</pre>
      </div>
    </div>
    <div class="row">
      <div class="col-md-6 action-bar">
        <font-awesome-icon
          icon="pencil-alt"
          @click="onSaveClick()"
          class="btn-icon default smaller"
        />
        <font-awesome-icon
          icon="trash"
          @click="onSaveClick()"
          class="btn-icon default smaller"
        />
      </div>
    </div>
    <div class="row">
      <div class="col-md-6 nav-bar">
        <div>
          <button class="btn btn-warning" @click="goToPreviousSeed()">Previous</button>
        </div>
        <div>
          <button class="btn btn-primary" @click="goToNextSeed()">Next</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import MemGrowCategoryDropdown from "./MemGrowCategoryDropdown";
import { SeedService } from "../services/SeedService";

var seedIndex = 0;

export default {
  data() {
    return {
      seeds: [],
      currentSeed: {}
    };
  },
  async created() {
    await this.loadSeeds();
  },
  methods: {
    async loadSeeds() {
      this.seeds = await SeedService.getSeeds();
      this.currentSeed = this.seeds[seedIndex];
    },
    hasNext() {
      return seedIndex + 1 < this.seeds.length;
    },
    hasPreviousSeed() {
      return seedIndex - 1 >= 0;
    },
    goToNextSeed() {
      if (this.hasNext()) {
        seedIndex += 1;
        this.currentSeed = this.seeds[seedIndex];
      }
    },
    goToPreviousSeed() {
      if (this.hasPreviousSeed()) {
        seedIndex -= 1;
        this.currentSeed = this.seeds[seedIndex];
      }
    }
  },
  components: { MemGrowCategoryDropdown }
};
</script>

<style>
.description-area {
  height: 200px;
  overflow: auto;
}
.action-bar {
  border-radius: 5px;
  padding: 15px;
  display: flex;
  justify-content: flex-end;
  background: #ccc;
  
}
.action-bar .btn-icon{
  margin-left: 15px;
}
.nav-bar {
  margin-top: 25px;
  display: flex;
  justify-content: space-between;
}
pre {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  font-size: 1rem;
}
</style>