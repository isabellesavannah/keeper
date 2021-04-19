<template>
  <div class="row">
    <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
      <keep-component v-for="k in state.keep" :key="k.id" :keep-prop="k" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { keepService } from '../services/KeepService'
export default {
  name: 'Home',
  setup() {
    const state = reactive({
      keep: computed(() => AppState.keeps)
    })
    onMounted(() => keepService.getKeeps())
    return { state }
  }
}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
}
</style>
