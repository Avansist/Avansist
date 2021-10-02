$(document).ready(function () {

    var current_fs, next_fs, previous_fs; //fieldsets
    var opacity;
    var current = 1;
    var steps = $("fieldset").length;

    setProgressBar(current);

    $(".next").click(function () {

        current_fs = $(this).parent();
        next_fs = $(this).parent().next();

        //Add Class Active
        $("#progressbar li").eq($("fieldset").index(next_fs)).addClass("active");

        //show the next fieldset
        next_fs.show();
        //hide the current fieldset with style
        current_fs.animate({ opacity: 0 }, {
            step: function (now) {
                // for making fielset appear animation
                opacity = 1 - now;

                current_fs.css({
                    'display': 'none',
                    'position': 'relative'
                });
                next_fs.css({ 'opacity': opacity });
            },
            duration: 500
        });
        setProgressBar(++current);
    });

    $(".previous").click(function () {

        current_fs = $(this).parent();
        previous_fs = $(this).parent().prev();

        //Remove class active
        $("#progressbar li").eq($("fieldset").index(current_fs)).removeClass("active");

        //show the previous fieldset
        previous_fs.show();

        //hide the current fieldset with style
        current_fs.animate({ opacity: 0 }, {
            step: function (now) {
                // for making fielset appear animation
                opacity = 1 - now;

                current_fs.css({
                    'display': 'none',
                    'position': 'relative'
                });
                previous_fs.css({ 'opacity': opacity });
            },
            duration: 500
        });
        setProgressBar(--current);
    });

    function setProgressBar(curStep) {
        var percent = parseFloat(100 / steps) * curStep;
        percent = percent.toFixed();
        $(".progress-bar")
            .css("width", percent + "%")
    }

    $(".submit").click(function () {
        return false;
    })

});

    //---------------------------------------VALIDACIONES DE LA VISTA---------------------------------------------

    // function EnviarDatos() {
    //     let RH = document.getElementById('FactorRh').value;

    //     if (RH.length == 0) {
    //       alertify.confirm("El RH no puede estar vacío.",
    //       function(){
    //       alertify.success('Ok');
    //       });            
    //     }
    //     else{

    //     }
    // }

    function ValidarRh(){
      var rh = document.getElementById('FactorRh');

      if (rh.value == 0 || rh.value =="") {
          alertify.confirm("El RH no puede estar vacío.",
          function(){
          alertify.success('Ok');
          });            
      }
      else {

      }
    }


    function ValidarTD(){
      var TDoc = document.getElementById('tipoDocumento')

      if (TDoc.value == 0 || TDoc.value == "") {
          alertify.confirm("El tipo de documento no puede estar vacío.",
          function(){
          alertify.success('Ok');
          });            
      }
      else {

      }
    }


    function JornadaSelect(){
      var jornada = document.getElementById('Jornada')

      if (jornada.value == 0 || rh.jornada =="") {
          alertify.confirm("Debe seleccionar una jornada.",
          function(){
          alertify.success('Ok');
          });            
      }
      else {

      }
    }

    function PadrinoSelect(){
      var padrino = document.getElementById('Padrino')

      if (padrino.value == 0 || rh.padrino =="") {
          alertify.confirm("Debe seleccionar un padrino.",
          function(){
          alertify.success('Ok');
          });            
      }
      else {

      }
    }

    function EstadoSelect(){
      var estado = document.getElementById('Estado')

      if (estado.value == 0 || rh.estado =="") {
          alertify.confirm("Debe seleccionar un estado.",
          function(){
          alertify.success('Ok');
          });            
      }
      else {

      }
    }



 //----------------------------------------------------VALIDACIÓN CON JQUERY----------------------------------------------------

//  $('#FactorRh').click(function() {

//   if ($('#FactorRh').val().trim() === '') {
//     alertify.confirm("La modalidad no puede estar vacía.",
//     function(){
//     alertify.success('Ok');
//     });
//   } 
//   else {
//   }
// });


 //********************************************************FIELDSET1****************************************************************

    // var expr = /^[a-zA-Z0-9_\.\-]+@[a-zA-Z0-9\-]+\.[a-zA-Z0-9\-\.]+$/;
    // $(document).ready(function(){
    //   $("#fieldset1").click(function(){
    //     var modalidad = $("#modalidad").val();

    //     if(modalidad == ""){
    //       alertify.confirm("La modalidad no puede estar vacía.",
    //       function(){
    //         alertify.success('Ok');
    //       });    
    //       return false;
    //     }

    //     else{
          
    //     }

    //   });

    // });


    // $('#modalidad').click(function(){
    //     // Swal.fire('La modalidad no puede estar vacía')   
    //     alertify.confirm("La modalidad no puede estar vacía.",
    //     function(){
    //       alertify.success('Ok');
    //     });    
    // });

    // $('#1NomAcud').click(function(){
    //     alertify.confirm("El nombre no puede estar vacío.",
    //     function(){
    //       alertify.success('Ok');
    //     });    
    // });

    // $('#1ApeAcud').click(function(){
    //     alertify.confirm("El apellido no puede estar vacío.",
    //     function(){
    //       alertify.success('Ok');
    //     });    
    // });

    // $('#FechIng').click(function(){
    //   alertify.confirm("La fecha de ingreso no puede estar vacía.",
    //   function(){
    //     alertify.success('Ok');
    //   });    
    // });

    // $('#FechNac').click(function(){
    //   alertify.confirm("La fecha de nacimiento no puede estar vacía.",
    //   function(){
    //     alertify.success('Ok');
    //   });    
    // });





//---------------------------------IMAGEN DE PERFIL------------------------

$(document).on("click", ".browse", function() {
    var file = $(this).parents().find(".file");
    file.trigger("click");
  });
  $('input[type="file"]').change(function(e) {
    var fileName = e.target.files[0].name;
    $("#file").val(fileName);
  
    var reader = new FileReader();
    reader.onload = function(e) {
      // get loaded data and render thumbnail.
      document.getElementById("preview").src = e.target.result;
    };
    // read the image file as a data URL.
    reader.readAsDataURL(this.files[0]);
  });