﻿function include(file) {
  var script = document.createElement('script');
  script.src = file;
  script.type = 'text/javascript';

  document.getElementsByTagName('head').item(0).appendChild(script);
}

include('/js/header.js');
include('/js/socialMedia.js');
include('/js/slider.js');
