<template>
  <div>
    <div class="row" style="margin-top:10px">
      <div class="col-md-6">
        <MemGrowCategoryDropdown
          :canAddNew="false"
          :selected="currentSeed.categoryId"
          @changed="onCategoryChanged"
        />
      </div>
    </div>
    <div class="row">
      <div class="col-md-6">
        <div class="action-bar">
          <div class="form-check">
            <input
              type="checkbox"
              class="form-check-input"
              id="exampleCheck1"
              v-model="useSameCategory"
              @change="onSameCategoryClick()"
            />
            <label class="form-check-label" for="exampleCheck1">Toon alleen huidige categorie</label>
          </div>
          <div class="icons">
            <router-link
              tag="a"
              class
              :to="{ name: 'EditMemGrow', params: { id: currentSeed.id } }"
            >
              <font-awesome-icon
                icon="pencil-alt"
                @click="onEditClick()"
                class="btn-icon default smaller"
              />
            </router-link>
            <font-awesome-icon
              icon="trash"
              @click="onDeleteClick()"
              class="btn-icon default smaller"
            />
          </div>
        </div>
      </div>
    </div>
    <div class="row description-area">
      <div class="col-md-6" style="white-space:pre-line">{{ currentSeed.description}}</div>
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
      currentSeed: {},
      useSameCategory: false
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
      var seeds = this.getNavigationSeeds();

      return seedIndex + 1 < seeds.length;
    },
    hasPreviousSeed() {
      if (seedIndex == 0) return false;

      let seeds = this.getNavigationSeeds();
      return seeds.length >= seedIndex - 1;
    },
    goToNextSeed() {
      if (this.hasNext()) {
        var seeds = this.getNavigationSeeds();
        seedIndex += 1;
        this.currentSeed = seeds[seedIndex];
      }
    },
    goToPreviousSeed() {
      if (this.hasPreviousSeed()) {
        var seeds = this.getNavigationSeeds();
        seedIndex -= 1;
        this.currentSeed = seeds[seedIndex];
      }
    },
    async onDeleteClick() {
      var result = confirm("Weet je zeker dat je dit zaadje wilt verwijderen?");

      if (result) {
        await SeedService.deleteSeed(this.currentSeed.id);

        this.seeds = this.seeds.filter(s => s.id != this.currentSeed.id);

        this.gotoNextAvailableSeed();
      }
    },
    onSameCategoryClick() {
      this.recalculateSeedIndex();
    },
    onCategoryChanged(categoryId) {
      var seed = this.seeds.find(s => s.categoryId == categoryId);

      if (seed) {
        this.useSameCategory = true;
        this.currentSeed = seed;
        this.recalculateSeedIndex();
      } else {
        alert("Categorie bevat geen inhoud.");
        let currentCat = this.currentSeed.categoryId;
        this.currentSeed.categoryId = 0;
        this.$nextTick(function() {
          this.currentSeed.categoryId = currentCat;
        });
      }
    },
    getNavigationSeeds() {
      let filteredSeeds = [];

      if (this.useSameCategory)
        filteredSeeds = this.seeds.filter(
          s => s.categoryId == this.currentSeed.categoryId
        );
      else filteredSeeds = this.seeds;

      return filteredSeeds;
    },
    recalculateSeedIndex() {
      var seeds = this.getNavigationSeeds();
      seedIndex = seeds.indexOf(this.currentSeed);
    },
    gotoNextAvailableSeed() {
      if (!this.hasNext() && !this.hasPreviousSeed())
        this.useSameCategory = false;

      if (this.hasNext()) {
        this.goToNextSeed();
      } else if (this.hasPreviousSeed()) {
        this.goToPreviousSeed();
      } else {
        console.warn("Geen volgende of vorige seed om naar te navigeren.");
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
  justify-content: space-between;
  display: flex;
  background: #fbf4f4;
  margin-top: 15px;
  margin-bottom: 15px;
}
.action-bar .btn-icon {
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