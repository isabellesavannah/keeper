<template>
  <div class="about text-center">
    <div class="row justify-content-start m-3">
      <div class="col-2">
        <img class="rounded" :src="state.account.picture" alt="" />
      </div>
      <div class="col-5">
        <h1>
          {{ state.account.name }}
        </h1>
      </div>
    </div>
    <div class="row justify-content-start">
      <div class="col-4">
        <h1>
          Vaults: {{ state.vaults.length }}
        </h1>
        <!-- <div class="col-4" v-if="state.showForm">
          <h3>Create a review!</h3>
          <form @submit.prevent="createReview">
            <div class="form-group">
              <input type="text"
                     class="form-control"
                     aria-describedby="helpId"
                     v-model="state.newReview.title"
              >
              <input type="text"
                     class="form-control"
                     aria-describedby="helpId"
                     v-model="state.newReview.body"
              >
              <input type="range" max="5" min="0" v-model="state.newReview.rating">
              <label for="">{{ state.newReview.rating }}</label>
              <input type="checkbox" v-model="state.newReview.published">
            </div>
            <button type="submit" class="btn btn-info">
              Create Review
            </button>
          </form>
        </div> -->
      </div>
    </div>
    <div class="row">
      <vault-component v-for="vault in state.vaults" :key="vault.id" :vault-prop="vault" />
    </div>
    <div class="row">
      <div class="col-5">
        <h1>
          Keeps: {{ state.keeps.length }}
        </h1>
      </div>
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
// import { useRoute } from 'vue-router'
export default {
  name: 'Account',
  setup() {
    // const route = useRoute
    const state = reactive({
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.activeKeep),
      vaults: computed(() => AppState.activeVault),
      showForm: false
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
