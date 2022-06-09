<template>
  <div class="content-container">
    <div class="section content-title-group">
      <h2 class="title">Planten</h2>
    </div>
    <div class="columns">
      <div class="column is-8">
        <div class="card edit-detail">
          <header class="card-header">
            <p class="card-header-title"></p>
          </header>
          <div class="card-content">
            <div class="content">
              <div class="field">
                <label class="label" for="id">Id</label>
                <label class="input" id="id" readonly></label>
              </div>
              <div class="field">
                <label class="label" for="name">Naam</label>
                <input class="input" id="name" />
              </div>
              <div class="field">
                <label class="label" for="description">Omschrijving</label>
                <textarea class="input" id="description" type="text" />
              </div>
              <div class="field">
                <label class="label" for="price">Prijs</label>
                <input class="number" id="price" step="0.01" />
              </div>
            </div>
          </div>
          <footer class="card-footer">
            <button class="link card-footer-item cancel-button">
              <i class="fas fa-undo"></i>
              <span>Cancel</span>
            </button>
            <button class="link card-footer-item">
              <i class="fas fa-save"></i>
              <span>Save</span>
            </button>
          </footer>
        </div>
        <div class="notification is-info"></div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'PlantOverview',
};
</script>
