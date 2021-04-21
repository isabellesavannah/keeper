<template>
  <router-link :to="{ name: 'VaultPage', params: { id: vaultProp.id } }" class="nav-link">
    <div class="vaultComponent card img-fluid">
      <h3>{{ vaultProp.name }}</h3>
      <p>{{ vaultProp.creator.name }}</p>
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
    },
    keepProp: {
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
