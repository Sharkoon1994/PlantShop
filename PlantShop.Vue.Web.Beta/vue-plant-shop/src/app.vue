<template>
  <div id="app">
    <HeaderBar />
    <div class="main-section columns">
      <main class="column">
        <PlantCreate />
        <PlantOverview />
      </main>
    </div>
  </div>
</template>

<script>
import HeaderBar from '@/components/header-bar';
import PlantCreate from '@/components/plant-create';
import PlantOverview from '@/components/plant-overview';

export default {
  name: 'App',
  components: { 
    HeaderBar, 
    PlantCreate, 
    PlantOverview 
  },
};
</script>

<style lang="scss">
@import '@/design/index.scss';
</style>