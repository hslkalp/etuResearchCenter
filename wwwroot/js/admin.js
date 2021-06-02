const currentLocation = location.href;
const menuItem = document.querySelectorAll('.nav-link');
const brandLink = document.querySelector('.brand-link');

menuItem.forEach((menuItem) => {
  if (menuItem.href === currentLocation) {
    menuItem.parentNode.parentNode.parentElement.classList.add('menu-open');
    menuItem.classList.add('active');
  }
});
