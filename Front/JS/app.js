  function mostrarMensaje() {
      swal("Información del Sistema", "Bienvenido a M&E proporcionado por EOR. Nos complace ofrecerle acceso al Servicio, sujeto a términos y condiciones provistos al momento de registrarse y a la Política de Privacidad correspondiente de Argentina. Al acceder y utilizar el Servicio, usted expresa su consentimiento, acuerdo y entendimiento de los Términos de Servicio y la Política de Privacidad. Si no está de acuerdo con los Términos de Servicio o la Política de Privacidad, no utilice el Servicio. Si utiliza el servicio está aceptando las modalidades operativas en vigencia descriptas más adelante, las declara conocer y aceptar.");
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
// GET TIPO ROL
    
      if ($("#contraseña").val() == 'Admin123456' && $("#email").val() == 'administrador@gmail.com' && $("#cboRo").val() == 1) {
          window.location.replace("./menu.html");
      } else if ($("#contraseña").val() == 'Gerente123456' && $("#email").val() == 'gerente@gmail.com' && $("#cboRo").val() == 2) {
          window.location.replace("./menuReporte.html");
      } else if ($("#contraseña").val() == 'Emple123456' && $("#email").val() == 'empleado@gmail.com' && $("#cboRo").val() == 3) {
          window.location.replace("./menuEmpleado.html");
      } else {
          swal("Error de Validacion", "Porfavor ingrese email, rol y contraseña correctos", "error");
      }


  }
