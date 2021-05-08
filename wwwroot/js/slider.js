/**
 * * slider
 */

var slider = new Vue({
  el: '#slider',
  data: {
    sliderData: []
  },
  mounted: function () {
    this.getirSlider();
  },
  methods: {
    getirSlider: function () {
      var vm = this;
      axios({
        method: 'post',
        url: 'Slider/GetirSlider',
        data: {
          sliderData: []
        }
      })
        .then(function (response) {
          vm.sliderData = response.data.sliderData;
          console.log(vm.sliderData);
        })
        .catch(function (error) {
          console.log(error);
        });
    }
  }
});
