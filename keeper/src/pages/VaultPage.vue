<template>
  <div class="vaultPage row w-100 justify-content-center">
    <div class="col">
      <router-link :to="{ name: 'Account' }" class="nav-link">
        <i class="fa fa-trash text-danger" @click="deleteVault" v-if="state.vault.creatorId == state.account.id" aria-hidden="true"></i>
      </router-link>
      {{ state.vault.name }}
    </div>
    <keep-component v-for="keep in state.keeps" :key="keep.id" :keep-prop="keep" />
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { computed, onMounted } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { keepService } from '../services/KeepService'
import { useRoute } from 'vue-router'
import { vaultService } from '../services/VaultService'
export default {
  name: 'VaultPage',
  setup() {
    const route = useRoute()
    const state = reactive({
      keeps: computed(() => AppState.keeps),
      vault: computed(() => AppState.activeVault),
      account: computed(() => AppState.account)
    })
    onMounted(() => keepService.getKeepsByVaultId(route.params.id))
    onMounted(() => vaultService.getVaultByVaultId(route.params.id))
    return {
      state,
      deleteVault() {
        vaultService.deleteVault(state.vault.id)
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
