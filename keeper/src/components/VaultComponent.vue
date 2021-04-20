<template>
  <router-link :to="{ name: 'VaultPage' }" class="nav-link">
    <div class="vaultComponent col-9 card m-1 img-fluid">
      <h3>{{ vaultProp.name }}</h3>
      <!-- <img class="img-fluid" :src="vaultProp.img" alt=""> -->
    </div>
  </router-link>
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
