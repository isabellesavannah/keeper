<template>
  <div class="keepComponent col-4 card m-1 img-fluid" data-toggle="modal" :data-target="`#keepModal` + keepProp.id">
    <img class="card-img" :src="keepProp.img" alt="Card image">
    <div class="card-img-overlay">
      <h3 class="text-white">
        {{ keepProp.name }}
      </h3>
      <div v-if="keepProp.creator">
        <p>{{ keepProp.id }}</p>
        <p>{{ keepProp.creator.name }}</p>
      </div>
    </div>
  </div>
  <div class="modal fade"
       :id="'keepModal' + keepProp.id"
       tabindex="-1"
       role="dialog"
       aria-hidden="true"
  >
    <div class="modal-dialog card" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <div class="col-7">
            <img class="img-fluid" :src="keepProp.img" alt="">
          </div>
          <div class="col-4">
            <h3>{{ keepProp.name }}</h3>
            <p>{{ keepProp.description }} As coders we find random text generators useful for our work, but they lack a certain je ne sais quoi to effortlessly integrate into our work. So, we've implemented a handful of quality of life improvements to make using this tool for fellow web designers and developers as hassle-free as possible.</p>
          </div>
          <div class="col-1">
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
        </div>
        <div class="modal-footer">
          <div class="col-4 w-100">
            <i class="fa fa-trash text-danger" @click="deleteKeep" v-if="keepProp.creatorId == state.account.id" aria-hidden="true" data-dismiss="modal"></i>
            <router-link v-if="keepProp.creatorId !== state.account.id" :to="{ name: 'ProfilePage', params: { id: keepProp.creatorId } }" class="nav-link" data-dismiss="modal">
              <img class="img-fluid" data-dismiss="modal" :src="keepProp.creator.picture" alt="">
            </router-link>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { useRoute } from 'vue-router'
import { AppState } from '../AppState'
import { keepService } from '../services/KeepService'
// import swal from 'sweetalert2'

export default {
  name: 'KeepComponent',
  props: {
    keepProp: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const route = useRoute()
    // const router = useRouter()
    const state = reactive({
      account: computed(() => AppState.account),
      keepProp: computed(() => AppState.keeps)
    })

    return {
      state,
      route,
      deleteKeep() {
        // swal({
        //   title: 'Delete Keep',
        //   icon: 'warning',
        //   buttons: true
        // })
        // swal.this((willDelete) => {
        //   if (willDelete) {
        //     swal({ icon: 'success' })
        //     keepService.deleteKeep(props.keepProp.id)
        //   } else {
        //     swal('Cancelled')
        //   }
        // })
        keepService.deleteKeep(props.keepProp.id)
      }
    }
  }
}
</script>

<style lang="scss" scoped>
.modal-dialog{
  max-width:70vw;
  max-height:40vh;
}

</style>
