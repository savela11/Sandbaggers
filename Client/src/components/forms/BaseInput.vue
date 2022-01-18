<template>
  <label :for="label" :class="'text-' + color">
    <span>{{ label }}</span>
    <input :type="inputType" :id="label" @input="$emit('update:modelValue', $event.target.value)">
  </label>
</template>

<script lang="ts">
import {defineComponent, ref} from "vue";

export default defineComponent({
  name: "BaseInput",
  props: {
    label: {
      type: String,
      required: true,
      default: 'defaultLabel',
    },
    color: {
      type: String,
      default: "blue"
    },
    inputType: {
     type: String,
     default: 'text'
    }
  },
  setup(props: any) {
    return {}

  }
})
</script>

<style lang="scss" scoped>
@use "../../assets/styles/_globals.scss" as g;
label {
  display: flex;
  flex-direction: column;
  padding: 1rem;

}

span {
  padding: 0 0 .3rem .3rem;
}

input, select, textarea {
  display: block;
  box-sizing: border-box;
  border: 1px solid darkgray;
  padding: .5rem 1rem;
  background-color: white;
  font-size: 1.4rem;
  width: 100%;
  outline: none;
  line-height: 1.2;
}

input, select {
  border-radius: 4px;

}

textarea {
  border-radius: 3px;
  min-height: 200px;
  white-space: pre-wrap;
  resize: none;

}

select {
  color: black;
  box-shadow: 0 0 2px gray;
  -webkit-appearance: none;
  -moz-appearance: none;

  option {
    border-color: gray;
    outline: none;
    color: black;
    background-color: transparent !important;

  }
}

input[type="date"] {
  &::-webkit-calendar-picker-indicator {
    height: 15px;
    width: 15px;
  }


}

input[type='radio'] {
  height: 25px;
  width: 25px;
  min-height: 0;
}

input[type='checkbox'] {
  height: 25px;
  width: 25px;
  min-height: 0;
}

</style>
