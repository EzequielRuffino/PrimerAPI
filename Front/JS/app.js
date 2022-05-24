  function mostrarMensaje() {
      swal("Información del Sistema", "Practica Profecional Supervisada de la Tecnicatura Universitaria en Programación, ciclo lectivo 2022.");
  }

  function go() {
      // Validación del Form
      var forms = document.getElementsByClassName('needs-validation');

      var validation = Array.prototype.filter.call(forms, function(form) {
          form.addEventListener('click', function(event) {
              if (form.checkValidity() === false) {
                  event.preventDefault();
                  event.stopPropagation();
              }
              form.classList.add('was-validated');
          }, false);
      });

//Logueo
    //var rol = document.getElementById('rol');
    // GET TIPO ROL
    //var idRol = rol.selectedIndex + 1;

    
      if ($("#contraseña").val() == 'Admin123456' && $("#email").val() == 'administrador@gmail.com' && $("#cboRol").val() == 1) {
          window.location.replace("./menu.html");
      } else if ($("#contraseña").val() == 'Gerente123456' && $("#email").val() == 'gerente@gmail.com' && $("#cboRol").val() == 2) {
          window.location.replace("./menu.html");
      } else if ($("#contraseña").val() == 'Emple123456' && $("#email").val() == 'empleado@gmail.com' && $("#cboRol").val() == 3) {
          window.location.replace("./remitos.html");
      } else {
          swal("Error de Validacion", "Porfavor ingrese email, rol y contraseña correctos", "error");
      }


  }