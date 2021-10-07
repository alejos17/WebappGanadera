// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
const formulario = document.getElementById("formulario");

const inputs = document.querySelectorAll('#formulario input');

const expresiones = {
  usuario: /^[a-zA-Z0-9\_\-]{4,16}$/,
  nombre: /^[a-zA-ZÀ-ÿ\s]{1,50}$/,
  apellidos: /^[a-zA-ZÀ-ÿ\s]{1,50}$/,
  password: /^.{4,12}$/,
  correo: /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9]+\.[a-zA-Z0-9-.]+$/,
  telefono: /^\d{7,14}$/
}

const campos = {
  usuario : false,
  nombre : false,
  apellidos: false,
  password : false,
  correo : false,
  telefono : false
}

const validarFormulario = (e) => {
  switch(e.target.name)
  {
    case "usuario":
      validarCampo(expresiones.usuario, e.target, 'usuario','user');
      break;

    case "nombre":
    validarCampo(expresiones.nombre, e.target, 'nombre','name');
    break;

    case "apellidos":
    validarCampo(expresiones.apellidos, e.target, 'apellidos','lname');
    break;

    case "correo":
    validarCampo(expresiones.correo, e.target, 'correo','mail');
    break;

    case "password":
    validarCampo(expresiones.password, e.target, 'password','pass');
    validarPassword2();
    break;

    case "password2":
    validarPassword2();
    break;

    case "telefono":
    validarCampo(expresiones.telefono, e.target,'telefono','phone');
    break;
  }
}

const validarCampo = (expresion, input, campo, i) => {
  if(expresion.test(input.value)){
    document.getElementById(`grupo__${campo}`).classList.remove('formulario__grupo-incorrecto');
    document.getElementById(`grupo__${campo}`).classList.add('formulario__grupo-correcto');
    document.querySelector(`#i${i}`).setAttribute("src","images/okIcon.png");
    document.querySelector(`#grupo__${campo} .formulario__input-error`).classList.remove('formulario__input-error-activo');
    campos[campo] = true;
  }else{
    document.getElementById(`grupo__${campo}`).classList.remove('formulario__grupo-correcto');
    document.getElementById(`grupo__${campo}`).classList.add('formulario__grupo-incorrecto');
    document.querySelector(`#i${i}`).setAttribute("src","images/alertIcon.png");
    document.querySelector(`#grupo__${campo} .formulario__input-error`).classList.add('formulario__input-error-activo');
  }

}
const validarPassword2 = () => {
  const inputPass1 = document.getElementById('password');
  const inputPass2 = document.getElementById('password2');

  if(inputPass1.value !== inputPass2.value){
    document.getElementById("grupo__password2").classList.remove('formulario__grupo-correcto');
    document.getElementById("grupo__password2").classList.add('formulario__grupo-incorrecto');
    document.querySelector("#ipass2").setAttribute("src","images/alertIcon.png");
    document.querySelector("#grupo__password2 .formulario__input-error").classList.add('formulario__input-error-activo');
    campos['password'] = false;
  }else{
    document.getElementById("grupo__password2").classList.remove('formulario__grupo-incorrecto');
    document.getElementById("grupo__password2").classList.add('formulario__grupo-correcto');
    document.querySelector("#ipass2").setAttribute("src","images/okIcon.png");
    document.querySelector("#grupo__password2 .formulario__input-error").classList.remove('formulario__input-error-activo');
    campos['password'] = true;
  }
}

inputs.forEach((input) => {
  input.addEventListener('keyup', validarFormulario);
  input.addEventListener('blur', validarFormulario);

});

formulario.addEventListener('submit', (e) => {
  e.preventDefault();
  const terminos = document.getElementById('terminos');

  if(campos.usuario && campos.nombre && campos.apellidos && campos.password && campos.correo && campos.telefono && terminos.checked){
    formulario.reset();
    document.getElementById('formulario__mensaje-exito').classList.add('formulario__mensaje-exito-activo');
    setTimeout(() => {
    document.getElementById('formulario__mensaje-exito').classList.remove('formulario__mensaje-exito-activo');
  }, 5000);
  document.querySelectorAll('.formulario__grupo-correcto').forEach((icono) => {
    icono.classList.remove('formulario__grupo-correcto');
  });
  }else{
    document.getElementById('formulario__mensaje').classList.add('formulario__mensaje-activo');
    setTimeout(() => {
    document.getElementById('formulario__mensaje').classList.remove('formulario__mensaje-activo');
  }, 4000);


  }
});
