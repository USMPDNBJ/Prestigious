// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var backgrounds = ['images/fondo3.png', 'images/fondo4.png', 'images/fondo1.png', 'images/fondo2.png']; // Asegúrate de proporcionar las rutas correctas de tus imágenes
var loadedImages = [];
var index = 0;

// Precargar todas las imágenes
function preloadImages() {
  for (var i = 0; i < backgrounds.length; i++) {
    var img = new Image();
    img.src = backgrounds[i];
    loadedImages.push(img);
  }
}

// Cambiar el fondo de manera fluida
function changeBackground() {
  var container = document.getElementById('fondox');
  container.style.backgroundImage = 'url(' + loadedImages[index].src + ')';
  index = (index + 1) % loadedImages.length; // Cambia al siguiente fondo de manera cíclica
}

// Inicia la precarga de imágenes y cambia el fondo cada 7 segundos
preloadImages();
setInterval(changeBackground, 7000);