/**
 * * slider
 */

var slider = new Vue({
  el: '#slider',
  data: {
    sliderVerisi: []
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
          sliderVerisi: []
        }
      })
        .then(function (response) {
          vm.sliderVerisi = response.data.gelendata;
          console.log(vm.sliderVerisi);
        })
        .catch(function (error) {
          console.log(error);
        });
    }
  }
});
