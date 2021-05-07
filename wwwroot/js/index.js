/**
 * * menu variable
 */
const mobileMenuBtn = document.getElementById('mobile-menu-btn');
const menu = document.getElementById('menu');
const subMenu = document.querySelectorAll('.sub-menu-icon');

/**
 * * slider variable
 */

const prev = document.getElementById('slider-prev-btn');
const next = document.getElementById('slider-next-btn');
const auto = true;
const interValTime = 5000;
let slideInterval;

/**
 * * social media variable
 */

const socialMediaBtn = document.querySelector('#social-media-btn');
const socialMediaMenu = document.querySelector('#social-media-menu');

/**
 * * arrow variable
 */

const arrow = document.querySelector('#arrow-cta');
const aboutWork = document.querySelector('#about');

/**
 *  * menu function
 */

mobileMenuBtn.addEventListener('click', () => {
  menu.classList.toggle('animate__fadeInUp');
  menu.classList.toggle('display-block');
});

subMenu.forEach((icon) => {
  icon.addEventListener('click', () => {
    icon.nextElementSibling.classList.toggle('active-menu');
  });
});

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

/**
 * * social media function
 */

socialMediaBtn.addEventListener('click', () => {
  socialMediaMenu.classList.toggle('social-menu-active');
  socialMediaMenu.classList.toggle('animate__bounceInDown');
});

/**
 * * arrow function
 */

arrow.addEventListener('click', () => {
  aboutWork.scrollIntoView();
});
