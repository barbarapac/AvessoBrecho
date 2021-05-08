// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

var roupa = window.document.getElementById('a_Roupas');
var caminho = window.document.getElementById('lbl_Caminho');

roupa.addEventListener('mouseup', selecionaRoupa);

function selecionaRoupa() {

    //alert('Aquiiii');
    roupa.style.fontSize = '20px';
    roupa.style.textDecoration = 'underline';
    caminho.innerText = 'Roupas';
}

$(document).ready(function () {
    selecionaRoupa;
});

// Write your JavaScript code.
