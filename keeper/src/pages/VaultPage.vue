<template>
  <div class="vaultPage row w-100">
    <keep-component v-for="keep in state.keeps" :key="keep.id" :keep-prop="keep" />
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { computed, onMounted } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { keepService } from '../services/KeepService'
import { useRoute } from 'vue-router'
export default {
  name: 'VaultPage',
  setup() {
    const route = useRoute()
    const state = reactive({
      keeps: computed(() => AppState.keeps)
    })
    onMounted(() => keepService.getKeepsByVaultId(route.params.id))
    return { state }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
