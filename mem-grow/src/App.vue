<template>
  <div id="app">
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
      <a class="navbar-brand" href="#">MemGrow</a>
      <button
        class="navbar-toggler"
        type="button"
        data-toggle="collapse"
        data-target="#navbarSupportedContent"
        aria-controls="navbarSupportedContent"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span class="navbar-toggler-icon"></span>
      </button>

      <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav mr-auto">
          <li class="nav-item active">
            <router-link to="/" class="nav-link">Home</router-link>
            <span class="sr-only">(current)</span>
          </li>
          <li class="nav-item">
            <router-link to="/addMemGrow" class="nav-link">Add seed</router-link>
          </li>
          <li class="nav-item">
            <router-link to="/about" class="nav-link">About</router-link>
          </li>
        </ul>
        <form class="form-inline my-2 my-lg-0" @submit.prevent="onSearch">
          <input
            class="form-control mr-sm-2"
            type="search"
            placeholder="Search"
            aria-label="Search"
            v-model="vm.keyword"
          />
          <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
        </form>
      </div>
    </nav>
    <div class="page-content">
      <router-view />
    </div>
  </div>
</template>

<script>
import $ from "jquery";

export default {
  data() {
    return {
      vm: {
        keyword: ""
      }
    };
  },
  watch: {
    $route(to) {
      document.title = to.meta.title || "MemGrow";
      $("#navbarSupportedContent").collapse("hide");
    }
  },
  created() {
    document.title = "MemGrow";
  },
  methods: {
    onSearch() {
      this.$router.push({ name: 'search', params:{keyword: this.vm.keyword} });
    }
  }
};
</script>

<style scoped>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}

.page-content {
  margin: 0 25px;
}
</style>
