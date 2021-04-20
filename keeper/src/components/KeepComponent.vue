<template>
  <div class="keepComponent col-5 card m-1 img-fluid">
    <h3>{{ keepProp.name }}</h3>
    <p>{{ keepProp.creator.name }}</p>
    <img class="img-fluid" :src="keepProp.img" alt="">
  </div>
</template>

<script>
import { reactive } from 'vue'
export default {
  name: 'KeepComponent',
  props: {
    keepProp: {
      type: Object,
      required: true
    }
  },
  setup() {
    const state = reactive({
    })
    return { state }
  }
}
</script>

<style lang="scss" scoped>

</style>
