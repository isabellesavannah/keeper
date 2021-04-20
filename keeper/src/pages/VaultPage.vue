<template>
  <div class="vaultPage">
    <div class="row">
      <keep-component v-for="keep in state.keeps" :key="keep.id" :keep-prop="keep" />
    </div>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { computed, onMounted } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { keepService } from '../services/KeepService'
export default {
  name: 'VaultPage',
  setup() {
    const state = reactive({
      keeps: computed(() => AppState.activeKeep)
    })
    onMounted(() => keepService.getKeepsByVaultId())
    return { state }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
