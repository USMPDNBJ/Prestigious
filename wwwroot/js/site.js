// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var backgrounds = ['images/fondo3.png','images/fondo4.png', 'images/fondo1.png','images/fondo2.png']; // Asegúrate de proporcionar las rutas correctas de tus imágenes

var index = 0;
function changeBackground() {
  var container = document.getElementById('fondox');
  container.style.backgroundImage = 'url(' + backgrounds[index] + ')';
  index = (index + 1) % backgrounds.length; // Cambia al siguiente fondo de manera cíclica
}

setInterval(changeBackground, 7000);