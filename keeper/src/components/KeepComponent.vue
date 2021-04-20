<template>
  <div class="keepComponent col-4 card m-1 img-fluid" data-toggle="modal" data-target="#keepModal">
    <img class="card-img" :src="keepProp.img" alt="Card image">
    <div class="card-img-overlay">
      <h3 class="text-white">
        {{ keepProp.name }}
      </h3>
    </div>
  </div>
  <div class="modal fade"
       id="keepModal"
       tabindex="-1"
       role="dialog"
       aria-hidden="true"
  >
    <div class="modal-dialog card" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <div class="row">
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
        </div>
      </div>
      <div class="modal-footer">
        <div class="row w-100">
          <img class="img-fluid" :src="keepProp.creator.picture" alt="">
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive } from 'vue'
export default {
  name: 'KeepComponent',
  props: {
    keepProp: {
      type: Object,
      required: true
    }
  },
  setup() {
    const state = reactive({
    })
    return { state }
  }
}
</script>

<style lang="scss" scoped>
.modal-dialog{
  max-width:80vw;
}

</style>
