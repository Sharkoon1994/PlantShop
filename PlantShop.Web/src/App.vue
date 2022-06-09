<template>
    <img alt="Vue logo" src="./assets/logo.png">
    <HelloWorld msg="HelloWorl" />
    <PlantOverview msg="Plant" />
</template>

<script>
    import HelloWorld from './components/HelloWorld.vue'
    import PlantOverview from './components/PlantOverview.vue'

    export default {
        name: 'app',
        components: {
            HelloWorld,
            PlantOverview
        }
    }
</script>

<style>
    #app {
        font-family: Avenir, Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #2c3e50;
        margin-top: 60px;
    }
</style>
