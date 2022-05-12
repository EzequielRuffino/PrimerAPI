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

      // Login
     var rol = document.getElementById('rol');
     var idRol = rol.selectedIndex + 1;

      if ($("#contraseña").val() == 'Admin123456' && $("#email").val() == 'administrador@gmail.com' && idRol == 1) {
          window.location.replace("./menu.html");
      } else if ($("#contraseña").val() == 'Gerente123456' && $("#email").val() == 'gerente@gmail.com' && idRol == 2) {
          window.location.replace("./menu.html");
      } else if ($("#contraseña").val() == 'Emple123456' && $("#email").val() == 'empleado@gmail.com' && idRol == 3) {
          window.location.replace("./remitos.html");
      } else {
          swal("Error de Validacion", "Porfavor ingrese email, rol y contraseña correctos", "error");
      }

     /* $ConnectionStrings=pg_connect 
       ("User ID=M&E; Password=123456; Server=localhost; Database=M&E; Integrated Security=true; Pooling=true");
    
      session_star();
      $usuario=$_POST['email'];
      $clave=$_POST['contraseña'];
      $rol=$_POST['rol'];

      $query="select * from usuario where email='$usuario' and contraseña ='$clave' and id_tipo_rol= '$rol'";

      $consulta=pg_query($ConnectionStrings, $query);
      $cantidad=pg_num_rows($consulta);
      
      if($cantidad>0){
          $_SESSION['nombre_usuario']=$usuario;
          window.location.replace("./menu.html");
      }else{
        swal("Error de Validacion", "Porfavor ingrese email, rol y contraseña correctos", "error");
      }*/

  }