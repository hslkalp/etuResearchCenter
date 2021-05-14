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

/**
 * * slider variable
 */

const prev = document.getElementById('slider-prev-btn');
const next = document.getElementById('slider-next-btn');
const auto = true;
const interValTime = 5000;
let slideInterval;

/**
 * * arrow variable
 */

const arrow = document.querySelector('#arrow-cta');
const aboutWork = document.querySelector('#about');
/**
 * * arrow function
 */



/**
 * * slider function
 */

const nextSlide = () => {
  const activeSlide = document.querySelector('.active');
  activeSlide.classList.remove('active');
  if (activeSlide.nextElementSibling) {
    activeSlide.nextElementSibling.classList.add('active');
  } else {
    const slides = document.querySelectorAll('.slide');
    slides[0].classList.add('active');
  }
};

const prevSlide = () => {
  const activeSlide = document.querySelector('.active');
  activeSlide.classList.remove('active');
  if (activeSlide.previousElementSibling) {
    activeSlide.previousElementSibling.classList.add('active');
  } else {
    const slides = document.querySelectorAll('.slide');
    slides[slides.length - 1].classList.add('active');
  }
};

next.addEventListener('click', () => {
  nextSlide();
  if (auto) {
    clearInterval(slideInterval);
    slideInterval = setInterval(nextSlide, interValTime);
  }
});

prev.addEventListener('click', () => {
  prevSlide();
  if (auto) {
    clearInterval(slideInterval);
    slideInterval = setInterval(prevSlide, interValTime);
  }
});

if (auto) {
  slideInterval = setInterval(nextSlide, interValTime);
}

arrow.addEventListener('click', () => {
  aboutWork.scrollIntoView();
});
