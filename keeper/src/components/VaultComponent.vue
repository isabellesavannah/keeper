<template>
  <router-link v-if="vaultProp.isPrivate == false || vaultProp.creatorId == state.account.id" :to="{ name: 'VaultPage', params: { id: vaultProp.id } }" class="nav-link">
    <div class="vaultComponent card img-fluid">
      <h3>{{ vaultProp.name }}</h3>
      {{ vaultProp.isPrivate }}
      <!-- <p>{{ vaultProp.creator.name }}</p> -->
    </div>
  </router-link>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'
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
      account: computed(() => AppState.account)
    })
    return { state }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
