/**
 * * menu variable
 */
const mobileMenuBtn = document.getElementById('mobile-menu-btn');
const menu = document.getElementById('menu');
const subMenu = document.querySelectorAll('.sub-menu-icon');

/**
 *  * menu function
 */

if (mobileMenuBtn != null) {
  mobileMenuBtn.addEventListener('click', () => {
    menu.classList.toggle('animate__fadeInUp');
    menu.classList.toggle('display-block');
  });
}

if (subMenu != null) {
  subMenu.forEach((icon) => {
    icon.addEventListener('click', () => {
      icon.nextElementSibling.classList.toggle('active-menu');
    });
  });
}
