/**
 * * slider
 */
var slider = new Vue({
  el: '#slider',
  data: {
    sliderData: []
  },
  mounted: function () {
    this.getSlider();
  },
  methods: {
    getSlider: function () {
      var vm = this;
      axios({
        method: 'post',
        url: 'Slider/GetSlider',
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
