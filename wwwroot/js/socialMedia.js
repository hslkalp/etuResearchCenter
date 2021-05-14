/**
 * * social media variable
 */

const socialMediaBtn = document.querySelector('#social-media-btn');
const socialMediaMenu = document.querySelector('#social-media-menu');

/**
 * * social media function
 */

socialMediaBtn.addEventListener('click', () => {
  socialMediaMenu.classList.toggle('social-menu-active');
  socialMediaMenu.classList.toggle('animate__bounceInDown');
});
