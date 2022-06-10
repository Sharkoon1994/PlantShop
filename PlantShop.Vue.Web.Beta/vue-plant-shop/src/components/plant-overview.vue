<template>
  <div class="content-container">
    <div class="section content-title-group">
      <h2 class="title">Overzicht</h2>
    </div>
    <div class="columns">
      <div class="column is-3">
        <header class="card-header">
          <p class="card-header-title">Planten</p>
        </header>
        <!-- Maak een lijst aan. -->
        <ul class=" list is-hoverable">
          <li v-for="plant in plants" :key="plant.id">
          <a class="list-item"
          @click="selectedPlant = plant"
          :class="{ 'is-active': selectedPlant == plant}">
          <span>{{ plant.name }}</span></a>
          </li>
        </ul>
      </div>
    </div>
    <div class="columns" v-if="selectedPlant">
      <div class="column is-3">
        <header class="card-header">
          <p class="card-header-title">{{ message }}</p>
        </header>
        <div class="card-content">
          <div class="content">
            <div class="field">
              <label class="label" for="id">Id:</label>
              <label class="input" id="id" readonly> {{ selectedPlant.id }}
              </label>
            </div>
            <div class="field">
              <label class="label" for="name">Naam:</label>
              <input
                class="input"
                id="name"
                v-model="selectedPlant.name"
              />
            </div> 
            <div class="field">
              <label for="show" class="checkbox">
                Meer tonen:
                <input
                  type="checkbox"
                  class="is-primary"
                  id="ShowContent"
                  v-model="showContent"
                />
              </label>
            </div>
            <div class="field" v-show="showContent">
              <label class="label" for="description">Beschrijving:</label>
              <input
                class="input"
                id="description"
                v-model="selectedPlant.description"
              />
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'PlantOverview',
  // Properties
  data() {
    return {
      selectedPlant: undefined,
      showContent: false,
      plants: [
        {
          id: 1,
          name: 'Gras',
          description: 'Heel erg groen'
        },
        {
          id: 2,
          name: 'Zonnebloem',
          description: 'Houd van de zon'
        },
        {
          id: 3,
          name: 'Boterbloem',
          description: 'Gemaakt van boter'
        }
      ],
      message: 'Plant',
    };
  },
};
</script>
