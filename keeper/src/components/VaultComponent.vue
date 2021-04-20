<template>
  <div class="vaultComponent col-5 card m-1 img-fluid">
    <h3>{{ vaultProp.name }}</h3>
    <img class="img-fluid" :src="vaultProp.img" alt="">
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
export default {
  name: 'VaultComponent',
  props: {
    vaultProp: {
      type: Object,
      required: true
    }
  },
  setup() {
    const state = reactive({
    })
    return { state }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
