<template>
  <div class="about text-center">
    <div class="row">
      <div class="col-4 card">
        <img class="rounded m-1" :src="state.account.picture" alt="" />
        <h1 class="float-right">
          {{ state.account.name }}
        </h1>
      </div>
    </div>
    <div class="row">
      <vault-component v-for="vault in state.vaults" :key="vault.id" :vault-prop="vault" />
    </div>
    <div class="row">
      <keep-component v-for="keep in state.keeps" :key="keep.id" :keep-prop="keep" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { keepService } from '../services/KeepService'
import { vaultService } from '../services/VaultService'
export default {
  name: 'Account',
  setup() {
    const state = reactive({
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.activeKeep),
      vaults: computed(() => AppState.activeVault)
      // newRestaurant: {}
    })
    onMounted(() => keepService.getKeepsByAccountId())
    onMounted(() => vaultService.getVaultsByAccountId())
    return { state }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
