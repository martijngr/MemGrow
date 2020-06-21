<template>
  <div>
    <div class="row">
      <div class="col-md-6">
          <MemGrowCategoryDropdown :canAddNew="false"/>
      </div>
    </div>
    <div class="row">
      <div class="col-md-6">
          Het zaadje
      </div>
    </div>
    <div class="row">
      <div class="col-md-6">
          navigatie
      </div>
    </div>
  </div>
</template>

<script>
import MemGrowCategoryDropdown from './MemGrowCategoryDropdown';
export default {
    components:{MemGrowCategoryDropdown}
};
</script>

<style>
</style>