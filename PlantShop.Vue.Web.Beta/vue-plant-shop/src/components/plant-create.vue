<template>
  <div class="content-container">
    <div class="section content-title-group">
      <h2 class="title">Plant</h2>
    </div>
    <div class="columns">
      <div class="column is-8">
        <div class="card edit-detail">
          <header class="card-header">
            <p class="card-header-title">{{ plant.name }}</p>
          </header>
          <div class="card-content">
            <div class="content">
              <div class="field">
                <label class="label" for="id">Id:</label>
                <label class="input" id="id" readonly>{{ plant.id }}</label>
              </div>
              <div class="field">
                <label class="label" for="name">Naam:</label>
                <input class="input" id="name" v-model="plant.name"/>
              </div>
              <div class="field">
                <label class="label" for="description">Omschrijving:</label>
                <textarea class="input" id="description" type="text" v-model="plant.description"
                />
              </div>
              <div class="field">
                <label class="label" for="price">Prijs:</label>
                <input class="input" id="price" v-model="plant.price" />
              </div>  
              <div class="field">
                <label for="category">
                  Category:
                  <div class="select is-primary">
                    <select id="category" v-model="plant.category"
                      :class="{ invalid: !plant.category }"
                      @keyup.esc="clearCategory">
                      <option disabled value>Selecteer:</option>
                      <option>Binnen</option>
                      <option>Buiten</option>
                    </select>
                  </div>
                </label>
              </div>
              <div class="field">
              <label class="checkbox" for="active">
                  Actief:
                  <input
                    type="checkbox"
                    class="is-primary"
                    id="active"
                    v-model="plant.active"
                  />
                </label>
              </div>
            </div>
          </div>
          <footer class="card-footer">
            <button class="link card-footer-item cancel-button" @click="cancelPlant">
              <i class="fas fa-undo"></i>
              <span>Ongedaan maken</span>
            </button>
            <button class="link card-footer-item save-button" @click="savePlant()">
              <i class="fas fa-save"></i>
              <span>Opslaan</span>
            </button>
          </footer>
        </div>
        <div class="card-notification" >
          <pre>{{ message }}</pre>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  // Naam van de Component.
  name: 'PlantCreate',
  // Gericht op data.
  data() {
    return {
      // Maak het object plant aan.
        plant: {
        id: 1,
        name: 'Orchidee',
        description: 'Een mooie plant',
        price: '7,50',
        category: '',
        active: true
      },
      message: '',
    };
  },
  // Gericht op het maken van methods.
  methods: {
    cancelPlant() {
      this.message = '';
    },
    clearCategory() {
      this.plant.category = '';
    },
    savePlant() {
      var json = this.message = JSON.stringify(this.plant, null, '\n');
      console.log(json)
    },
  },
};
</script>
